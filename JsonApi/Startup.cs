using JsonApi.Models;
using JsonApiDotNetCore.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JsonApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql("server=localhost;port=5432;user id=user;password=pass;database=JsonApi");
            }, ServiceLifetime.Transient);

            services.AddJsonApi<AppDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, AppDbContext context, IHostingEnvironment env)
        {
            if (context.Videos.Any() == false)
            {
                context.Videos.Add(new Video
                {
                    Name = "Creating New Promises",
                    Description = "<p>Sometimes you want to start a new promise chain or have greater control over the timing of events. By manually creating a promise, you can do that.</p><p>In this video we cover creating a new promise and resolving or rejecting the promise. We use two examples- a custom AJAX login and an Ember Data findAll request.</p>",
                    Thumbnail = "https://vue-screencasts.s3.us-east-2.amazonaws.com/images/video-thumbnails/Thumbnail+-+Creating+New+Promises.png",
                    VideoUrl = "https://vue-screencasts.s3.us-east-2.amazonaws.com/video-files/EmberScreencast+93+-+Creating+New+Promises.mp4"
                });
                context.Videos.Add(new Video
                {
                    Name = "Multiple Concurrent Promises",
                    Description = "<p>Sometimes promises have to happen in an exact order, but often there will be several calls that can be made concurrently. RSVP’s Promise implementation allows that.</p><p>In this video we show how to use the hash method, one of several methods available to do concurrent promises.</p>",
                    Thumbnail = "https://vue-screencasts.s3.us-east-2.amazonaws.com/images/video-thumbnails/Thumbnail+-+Multiple+Concurrent+Promises.png",
                    VideoUrl = "https://vue-screencasts.s3.us-east-2.amazonaws.com/video-files/EmberScreencast+95+-+Multiple+Concurrent+Promises.mp4"
                });
                context.Videos.Add(new Video
                {
                    Name = "ES2015 Destructuring",
                    Description = "<p>Destructuring is really cool, can save you code, and you’re probably already using a small portion of its power.</p><p>Learn more about this cool new ES2015/ES6 feature, including how to destructure deeply nested objects, how to use it with Ember’s import statement, and how to use it with arrays.</p>",
                    Thumbnail = "https://vue-screencasts.s3.us-east-2.amazonaws.com/images/video-thumbnails/Thumbnail+-+Destructuring.png",
                    VideoUrl = "https://vue-screencasts.s3.us-east-2.amazonaws.com/video-files/EmberScreencast+114+-+ES2015+Destructuring.mp4"
                });
                context.Videos.Add(new Video
                {
                    Name = "ES2016 Decorators",
                    Description = "<p>Decorators let you easily and repeatedly add functionality to existing functions.</p><p>In this episode we go over how to use and create decorators, creating two useful decorators that demonstrate different parts of the API.</p>",
                    Thumbnail = "https://vue-screencasts.s3.us-east-2.amazonaws.com/images/video-thumbnails/Thumbnail+-+Decorators.png",
                    VideoUrl = "https://vue-screencasts.s3.us-east-2.amazonaws.com/video-files/EmberScreencast+115+-+ES2016+Decorators.mp4"
                });
                context.Videos.Add(new Video
                {
                    Name = "ES2015 Arrow Functions",
                    Description = "<p>ES2015 (aka ES6) has some great ways to make your code easier to write and understand. In this episode, we cover two different ways that you can make your code clearer by removing the 'function' keyword.</p>",
                    Thumbnail = "https://vue-screencasts.s3.us-east-2.amazonaws.com/images/video-thumbnails/Thumbnail+-+Arrow+Function.png",
                    VideoUrl = "https://vue-screencasts.s3.us-east-2.amazonaws.com/video-files/38-+es2015-+functions+minus+'function'.mp4"
                });
                context.Videos.Add(new Video
                {
                    Name = "ES2015 Template Strings",
                    Description = "<p>Template strings are an incredibly useful new feature in ES2015... and you can use them in your Ember apps today!</p><p>Here are 3 cool things that template strings enable.</p>",
                    Thumbnail = "https://vue-screencasts.s3.us-east-2.amazonaws.com/images/video-thumbnails/Thumbnail+-+Template+Strings.png",
                    VideoUrl = "https://vue-screencasts.s3.us-east-2.amazonaws.com/video-files/42-+ES2015+template+strings.mp4"
                });
                context.Videos.Add(new Video
                {
                    Name = "ES2015 Modules",
                    Description = "<p>Before modules, javascript code loading was a mess. Now it's pretty amazing.</p><p>Learn about ES2015 modules and how they work together with ember-cli.</p>",
                    Thumbnail = "https://vue-screencasts.s3.us-east-2.amazonaws.com/images/video-thumbnails/Thumbnail+-+ES2015+Modules.png",
                    VideoUrl = "https://vue-screencasts.s3.us-east-2.amazonaws.com/video-files/EmberScreencast+62+-+ES2015+Modules+-+Import%2C+Export.mp4"
                });
                context.Videos.Add(new Video
                {
                    Name = "Promise Basics",
                    Description = "<p>Promises are a tool for handling asynchronous communication, and they are commonly used in Ember applications. They’re even built in to Ember Data, route handling, and other parts of the Ember source.</p><p>This episode introduces the then, catch, and finally blocks, how to chain them together, and how to use them with either named or anonymous functions.</p>",
                    Thumbnail = "https://vue-screencasts.s3.us-east-2.amazonaws.com/images/video-thumbnails/Thumbnail+-+Promise+Basics.png",
                    VideoUrl = "https://vue-screencasts.s3.us-east-2.amazonaws.com/video-files/EmberScreencast+92+-+Promises+Basics.mp4"
                });
                context.SaveChanges();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseJsonApi();
        }
    }
}
