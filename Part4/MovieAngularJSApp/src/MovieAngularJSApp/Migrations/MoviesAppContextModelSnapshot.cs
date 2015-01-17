using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using MovieAngularJSApp.Models;
using System;

namespace MovieAngularJSApp.Migrations
{
    [ContextType(typeof(MovieAngularJSApp.Models.MoviesAppContext))]
    public class MoviesAppContextModelSnapshot : ModelSnapshot
    {
        public override IModel Model
        {
            get
            {
                var builder = new BasicModelBuilder();
                
                builder.Entity("MovieAngularJSApp.Models.Movie", b =>
                    {
                        b.Property<string>("Director");
                        b.Property<int>("Id")
                            .GenerateValueOnAdd();
                        b.Property<string>("Title");
                        b.Key("Id");
                    });
                
                return builder.Model;
            }
        }
    }
}