using BlazorApp.Components;
using BlazorApp.Components.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


#region DI 설정

//DI 설정
builder.Services.AddSingleton<FoodService.IFoodService, FoodService.KoreanFoodService>();
builder.Services.AddSingleton<FoodService.PaymentService>(); //생성자에서 알아서 연결 해줌 (스프링과 같이)
//스프링빈 같은것을 생성할때 3가지 모드
//1. AddSingleton 
//2. AddTransient 
//3. AddScoped 
// https://afsdzvcx123.tistory.com/entry/ASPNET-Core-%EC%84%9C%EB%B9%84%EC%8A%A4-%EC%83%9D%EB%AA%85%EC%A3%BC%EA%B8%B0-Singleton-Scoped-Transient
// https://velog.io/@zeehyo2216/Blazor-DI-Singleton-Scoped-Transient 참고
//https://learn.microsoft.com/ko-kr/aspnet/core/blazor/fundamentals/dependency-injection?view=aspnetcore-8.0
builder.Services.AddSingleton<FoodService.SingletonService>();
builder.Services.AddTransient<FoodService.TransientService>();
builder.Services.AddScoped<FoodService.ScopedService>();


#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();