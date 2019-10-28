/*
 * Copyright (c) 2018 Google Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not
 * use this file except in compliance with the License. You may obtain a copy of
 * the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations under
 * the License.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using Aspose.Pdf.Text.TextOptions;

namespace HelloWorld
{
    // [START gae_flex_quickstart]
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                var pdf = new  Aspose.Pdf.Document("hola.pdf");
                // Create TextAbsorber object to extract text
                TextAbsorber textAbsorber = new TextAbsorber(new TextExtractionOptions(TextExtractionOptions.TextFormattingMode.Raw));
                // Accept the absorber for all the pages
                pdf.Pages[1].Accept(textAbsorber);
                String extractedText = textAbsorber.Text;
                //string greeting = Configuration["My:Greeting"];
                await context.Response.WriteAsync(extractedText);
            });
        }
    }
    // [END gae_flex_quickstart]
}
