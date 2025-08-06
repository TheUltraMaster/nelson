using Api.Mapper;
using Database.Data;
using Microsoft.EntityFrameworkCore;
using HotChocolate.Validation;
using AppAny.HotChocolate.FluentValidation;


var builder = WebApplication.CreateBuilder(args);

builder.AddGraphQL().AddTypes()
.AddProjections()
.AddFiltering()
.AddSorting()
.AddPagingArguments().AddFluentValidation();

builder.Services.AddDbContext<DatabseContext>(opt => opt.UseMySQL("Server=localhost;Database=Nelson;Uid=root;Pwd=Judith0709;Convert Zero Datetime=True;"));

builder.Services.AddSingleton<Mapa>();
var app = builder.Build();


app.MapGraphQL();

app.RunWithGraphQLCommands(args);
