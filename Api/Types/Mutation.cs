using Database.DTOS;
using Api.Mapper;
using Database.Data;
using Database.Models;
using Api.Mapper;

namespace Api.Types
{
    [MutationType]
    public class Mutation
    {


               
        // Animale mutations
        public async Task<Animale> CreateAnimale(AnimaleCreateDto dto, [Service] DatabseContext db, [Service] Mapa mapper)
        {
            var entity = mapper.AnimaleCreateDtoToAnimale(dto);
            db.Animales.Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }


        public async Task<Archivo> CreateArchivo(ArchivoCreateDto dto, [Service] DatabseContext db, [Service] Mapa mapper)
        {
            var entity = mapper.ArchivoCreateDtoToArchivo(dto);
            db.Archivos.Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }

 
        public async Task<BitacoraAlimento> CreateBitacoraAlimento(BitacoraAlimentoCreateDto dto, [Service] DatabseContext db, [Service] Mapa mapper)
        {
            var entity = mapper.BitacoraAlimentoCreateDtoToBitacoraAlimento(dto);
            db.BitacoraAlimentos.Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }


        public async Task<BitacoraPeso> CreateBitacoraPeso(BitacoraPesoCreateDto dto, [Service] DatabseContext db, [Service] Mapa mapper)
        {
            var entity = mapper.BitacoraPesoCreateDtoToBitacoraPeso(dto);
            db.BitacoraPesos.Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }



        public async Task<BitacorasVacuna> CreateBitacorasVacuna(BitacorasVacunaCreateDto dto, [Service] DatabseContext db, [Service] Mapa mapper)
        {
            var entity = mapper.BitacorasVacunaCreateDtoToBitacorasVacuna(dto);
            db.BitacorasVacunas.Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }


        public async Task<CompraAlimento> CreateCompraAlimento(CompraAlimentoCreateDto dto, [Service] DatabseContext db, [Service] Mapa mapper)
        {
            var entity = mapper.CompraAlimentoCreateDtoToCompraAlimento(dto);
            db.CompraAlimentos.Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }


        public async Task<HistorialAlimenticio> CreateHistorialAlimenticio(HistorialAlimenticioCreateDto dto, [Service] DatabseContext db, [Service] Mapa mapper)
        {
            var entity = mapper.HistorialAlimenticioCreateDtoToHistorialAlimenticio(dto);
            db.HistorialAlimenticios.Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }



        public async Task<Reporte> CreateReporte(ReporteCreateDto dto, [Service] DatabseContext db, [Service] Mapa mapper)
        {
            var entity = mapper.ReporteCreateDtoToReporte(dto);
            db.Reportes.Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }


        public async Task<Animale> updateAnimale(AnimaleCreateDto dto, [Service] DatabseContext db, [Service] Mapa mapper)
        {
            var entity = mapper.AnimaleCreateDtoToAnimale(dto);
            db.Animales.Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }

    
 
         public async Task<Archivo> updateArchivo(ArchivoCreateDto dto, [Service] DatabseContext db, [Service] Mapa mapper)
        {
            var entity = mapper.ArchivoCreateDtoToArchivo(dto);
            db.Archivos.Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }


        // BitacoraAlimento mutations
        public async Task<BitacoraAlimento> updateBitacoraAlimento(BitacoraAlimentoCreateDto dto, [Service] DatabseContext db, [Service] Mapa mapper)
        {
            var entity = mapper.BitacoraAlimentoCreateDtoToBitacoraAlimento(dto);
            db.BitacoraAlimentos.Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        // BitacoraPeso mutations

        public async Task<BitacoraPeso> updateBitacoraPeso(BitacoraPesoCreateDto dto, [Service] DatabseContext db, [Service] Mapa mapper)
        {
            var entity = mapper.BitacoraPesoCreateDtoToBitacoraPeso(dto);
            db.BitacoraPesos.Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        // BitacorasVacuna mutations

        public async Task<BitacorasVacuna> updateBitacorasVacuna(BitacorasVacunaCreateDto dto, [Service] DatabseContext db, [Service] Mapa mapper)
        {
            var entity = mapper.BitacorasVacunaCreateDtoToBitacorasVacuna(dto);
            db.BitacorasVacunas.Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }


        // CompraAlimento mutations

        public async Task<CompraAlimento> updateCompraAlimento(CompraAlimentoCreateDto dto, [Service] DatabseContext db, [Service] Mapa mapper)
        {
            var entity = mapper.CompraAlimentoCreateDtoToCompraAlimento(dto);
            db.CompraAlimentos.Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        // HistorialAlimenticio mutations
   
        public async Task<HistorialAlimenticio> updateHistorialAlimenticio(HistorialAlimenticioCreateDto dto, [Service] DatabseContext db, [Service] Mapa mapper)
        {
            var entity = mapper.HistorialAlimenticioCreateDtoToHistorialAlimenticio(dto);
            db.HistorialAlimenticios.Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        // Reporte mutations
            
        public async Task<Reporte> updateReporte(ReporteCreateDto dto, [Service] DatabseContext db, [Service] Mapa mapper)
        {
            var entity = mapper.ReporteCreateDtoToReporte(dto);
            db.Reportes.Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }





    }
}