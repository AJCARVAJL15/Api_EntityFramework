using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using proyectoef.Models;
namespace proyectoef.Models;

    public class TareasContext : DbContext
    {

        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }


        public TareasContext(DbContextOptions<TareasContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Categoria> categoriasInit=new List<Categoria>();
            categoriasInit.Add(new Categoria() {CategoriaId=Guid.Parse("53f5f62b-088e-43c4-b866-bc14dd34e5d0"), Nombre="Actividades pendientes", Peso=20 });
            categoriasInit.Add(new Categoria() {CategoriaId=Guid.Parse("7542bf1c-fc5e-4ad4-b11b-35db66b4a707"), Nombre="Actividades realizadas", Peso=50 });


            modelBuilder.Entity<Categoria>(categoria=>
            {
                categoria.ToTable("Categoria");
                categoria.HasKey(p=>p.CategoriaId);
                categoria.Property(p => p.Nombre).HasMaxLength(50).IsRequired();
			    categoria.Property(p => p.Descripcion).IsRequired(false);
                categoria.Property(p=>p.Peso);
                categoria.HasData(categoriasInit);


            });

             List<Tarea> tareasInit=new List<Tarea>();
             tareasInit.Add(new Tarea(){TareaId=Guid.Parse("f50539e8-c941-4a7b-9869-a179c728e590"), CategoriaId=Guid.Parse("53f5f62b-088e-43c4-b866-bc14dd34e5d0"), PrioridadTarea=Prioridad.media, Titulo="Pago de servicios publicos", FechaCreacion=DateTime.Now});
              tareasInit.Add(new Tarea(){TareaId=Guid.Parse("e6bfaa3b-05a3-4fe6-8936-fbbb1f72f54d"), CategoriaId=Guid.Parse("7542bf1c-fc5e-4ad4-b11b-35db66b4a707"), PrioridadTarea=Prioridad.media, Titulo="Estudiar nuevos temas", FechaCreacion=DateTime.Now});   
            modelBuilder.Entity<Tarea>(tarea=>
            
            {
                tarea.ToTable("Tarea");
                tarea.HasKey(p=> p.TareaId);
                tarea.HasOne(p=>p.Categoria).WithMany(p=>p.Tareas).HasForeignKey(p=> p.CategoriaId);
                tarea.Property(p=> p.Titulo).IsRequired().HasMaxLength(200);
                tarea.Property(p=>p.Descripcion).IsRequired(false);
                tarea.Property(p=>p.PrioridadTarea);
                tarea.Property(p=>p.FechaCreacion);
                tarea.Ignore(p=>p.Resumen);
                tarea.HasData(tareasInit);
            });




        }
    }
