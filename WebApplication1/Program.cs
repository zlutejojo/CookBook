using CookBook.Recipe.Content; // needed only to use the class without full class name

// visibility:
// inside project only: private, internal, protected, protected internal
// outside: public, protected (inherited call in another project), 
// protected internal == protected OR internal


// fully qualified name of the class
CookBook.Recipe.Content.CookBookManager c1;
CookBookManager c2; // needs using


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
