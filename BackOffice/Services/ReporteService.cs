using Database.Data;
using Database.Models;
using Database.DTOS;
using Microsoft.EntityFrameworkCore;

namespace BackOffice.Services
{
    public interface IReporteService
    {
        Task<(List<Reporte> reportes, int totalCount)> GetReportesPaginadosAsync(int page, int pageSize);
        Task<Reporte?> GetReporteByIdAsync(int id);
        Task<Reporte> CreateReporteAsync(ReporteCreateDto reporteDto);
        Task<Reporte?> UpdateReporteAsync(int id, ReporteCreateDto reporteDto);
        Task<bool> DeleteReporteAsync(int id);
        Task<List<Animale>> GetAnimalesAsync();
        Task<List<Empleado>> GetEmpleadosAsync();
    }

    public class ReporteService : IReporteService
    {
        private readonly DatabseContext _context;

        public ReporteService(DatabseContext context)
        {
            _context = context;
        }

        public async Task<(List<Reporte> reportes, int totalCount)> GetReportesPaginadosAsync(int page, int pageSize)
        {
            var totalCount = await _context.Reportes.CountAsync();
            
            var reportes = await _context.Reportes
                .Include(r => r.Animal)
                    .ThenInclude(a => a.Raza)
                .Include(r => r.Empleado)
                .OrderByDescending(r => r.FechaRegistro)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (reportes, totalCount);
        }

        public async Task<Reporte?> GetReporteByIdAsync(int id)
        {
            return await _context.Reportes
                .Include(r => r.Animal)
                    .ThenInclude(a => a.Raza)
                .Include(r => r.Empleado)
                .Include(r => r.Archivos)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Reporte> CreateReporteAsync(ReporteCreateDto reporteDto)
        {
            var reporte = new Reporte
            {
                AnimalId = reporteDto.AnimalId,
                EmpleadoId = reporteDto.EmpleadoId,
                Descripcion = reporteDto.Descripcion,
                FechaRegistro = DateTime.Now
            };

            _context.Reportes.Add(reporte);
            await _context.SaveChangesAsync();
            return await GetReporteByIdAsync(reporte.Id) ?? reporte;
        }

        public async Task<Reporte?> UpdateReporteAsync(int id, ReporteCreateDto reporteDto)
        {
            var existingReporte = await _context.Reportes.FindAsync(id);
            if (existingReporte == null) return null;

            existingReporte.AnimalId = reporteDto.AnimalId;
            existingReporte.EmpleadoId = reporteDto.EmpleadoId;
            existingReporte.Descripcion = reporteDto.Descripcion;

            await _context.SaveChangesAsync();
            return await GetReporteByIdAsync(id);
        }

        public async Task<bool> DeleteReporteAsync(int id)
        {
            var reporte = await _context.Reportes.FindAsync(id);
            if (reporte == null) return false;

            _context.Reportes.Remove(reporte);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Animale>> GetAnimalesAsync()
        {
            return await _context.Animales
                .Include(a => a.Raza)
                .OrderBy(a => a.CodigoRfid)
                .ToListAsync();
        }

        public async Task<List<Empleado>> GetEmpleadosAsync()
        {
            return await _context.Empleados
                .OrderBy(e => e.PrimerNombre)
                .ThenBy(e => e.PrimerApellido)
                .ToListAsync();
        }
    }
}