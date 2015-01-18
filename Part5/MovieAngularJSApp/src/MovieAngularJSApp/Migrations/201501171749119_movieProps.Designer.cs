using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using MovieAngularJSApp.Models;
using System;

namespace MovieAngularJSApp.Migrations
{
    [ContextType(typeof(MovieAngularJSApp.Models.MoviesAppContext))]
    public partial class movieProps : IMigrationMetadata
    {
        string IMigrationMetadata.MigrationId
        {
            get
            {
                return "201501171749119_movieProps";
            }
        }
        
        string IMigrationMetadata.ProductVersion
        {
            get
            {
                return "7.0.0-beta2-11909";
            }
        }
        
        IModel IMigrationMetadata.TargetModel
        {
            get
            {
                var builder = new BasicModelBuilder();
                
                builder.Entity("MovieAngularJSApp.Models.Movie", b =>
                    {
                        b.Property<string>("Director");
                        b.Property<int>("Id")
                            .GenerateValueOnAdd();
                        b.Property<DateTime>("ReleaseDate");
                        b.Property<decimal>("TicketPrice");
                        b.Property<string>("Title");
                        b.Key("Id");
                    });
                
                return builder.Model;
            }
        }
    }
}