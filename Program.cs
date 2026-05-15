using InstagramDatabase;


Console.WriteLine("Iniciando aplicación...");

using var db = new InstagramDbContext();

bool creada = db.Database.EnsureCreated();

if (creada) Console.WriteLine("Base de datos creada exitosamente.");
else Console.WriteLine("La base de datos ya existe.");






