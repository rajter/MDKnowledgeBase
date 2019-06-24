#pragma checksum "c:\Projects\KnowledgeBase\Views\KnowledgeBase\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e74aa72c648b5637b6cf4d0ae5deb35e58e81569"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_KnowledgeBase_Index), @"mvc.1.0.view", @"/Views/KnowledgeBase/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/KnowledgeBase/Index.cshtml", typeof(AspNetCore.Views_KnowledgeBase_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "c:\Projects\KnowledgeBase\Views\_ViewImports.cshtml"
using KnowledgeBase;

#line default
#line hidden
#line 2 "c:\Projects\KnowledgeBase\Views\_ViewImports.cshtml"
using KnowledgeBase.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e74aa72c648b5637b6cf4d0ae5deb35e58e81569", @"/Views/KnowledgeBase/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5af3872e11202954872bff0ef9cf1ab1c685697f", @"/Views/_ViewImports.cshtml")]
    public class Views_KnowledgeBase_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "c:\Projects\KnowledgeBase\Views\KnowledgeBase\Index.cshtml"
  
    IEnumerable<MarkDownFile> MarkdownFiles = ViewBag.MarkdownFiles;
    string document = ViewBag.Document;
    Folder rootFolder = ViewBag.RootFolder;

#line default
#line hidden
            BeginContext(163, 247, true);
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-2\" style=\"padding: 0\">        \r\n        <div class=\"sidebar\">\r\n            <div class=\"input-group\" style=\"width: 95%; margin: 5px;\">\r\n                <input \r\n                    v-model=\"searchPattern\"");
            EndContext();
            BeginWriteAttribute("v-on:keyup.enter", "\r\n                    v-on:keyup.enter=\"", 410, "\"", 477, 3);
            WriteAttributeValue("", 450, "SearchMarkdown(\'", 450, 16, true);
#line 13 "c:\Projects\KnowledgeBase\Views\KnowledgeBase\Index.cshtml"
WriteAttributeValue("", 466, document, 466, 9, false);

#line default
#line hidden
            WriteAttributeValue("", 475, "\')", 475, 2, true);
            EndWriteAttribute();
            BeginContext(478, 435, true);
            WriteLiteral(@"
                    placeholder=""Search""
                    class=""form-control"" type=""search"" placeholder=""Search"" aria-label=""Search"">
                <span class=""input-group-btn"">
                    <button class=""btn btn-default"" type=""button"" v-on:click=""ClearSearch""><i class=""fas fa-times""></i></button>
                </span>
            </div>

            <li v-for=""result in searchResults"">
                <a");
            EndContext();
            BeginWriteAttribute("v-on:click", " v-on:click=\"", 913, "\"", 975, 4);
            WriteAttributeValue("", 926, "fetchMarkdown(result.normalizedPath,", 926, 36, true);
            WriteAttributeValue(" ", 962, "\'", 963, 2, true);
#line 22 "c:\Projects\KnowledgeBase\Views\KnowledgeBase\Index.cshtml"
WriteAttributeValue("", 964, document, 964, 9, false);

#line default
#line hidden
            WriteAttributeValue("", 973, "\')", 973, 2, true);
            EndWriteAttribute();
            BeginContext(976, 111, true);
            WriteLiteral(" class=\"\">{{ result.name }}</a>\r\n            </li>\r\n\r\n            <h2 style=\"text-align: center\" id=\"document\">");
            EndContext();
            BeginContext(1088, 8, false);
#line 25 "c:\Projects\KnowledgeBase\Views\KnowledgeBase\Index.cshtml"
                                                    Write(document);

#line default
#line hidden
            EndContext();
            BeginContext(1096, 1062, true);
            WriteLiteral(@"</h2>
            <div class=""root-folder"">
                <tree-item 
                    :item=""rootFolder"" 
                    v-on:fetch-markdown=""fetchMarkdown"">
                </tree-item>
            </div>
        </div>
    </div>
    <div class=""col-md-9"" style=""padding-top: 10px;"">
        <textarea id=""MDTextArea"" class=""hidden""></textarea>
        <div id=""markdown-content""></div>   
    </div>
    <div class=""col-md-1"" style=""padding-top: 10px;"">
        <button class=""btn"" v-on:click=""StartEdit"" v-show=""!editing""><i class =""fas fa-edit""></i></button>
        <button class=""btn"" v-on:click=""HtmlToPdf"" v-show=""!editing""><i class =""fas fa-print""></i></button>
        <div class=""btn-group"" role=""group"" aria-label=""Basic example"">
            <button class=""btn btn-primary"" v-on:click=""SaveEdit"" v-show=""editing""><i class =""fas fa-save""></i></button>
            <button class=""btn btn-danger"" v-on:click=""CancelEdit"" v-show=""editing""><i class =""fas fa-times""></i></button>
      ");
            WriteLiteral("  </div>\r\n    </div>\r\n    \r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2176, 4327, true);
                WriteLiteral(@"
    <!-- item template -->
    <script type=""text/x-template"" id=""item-template"">
        <div class=""md-folder"">
                <!-- :class=""{'bold': isFolder}"" -->
            <a  v-on:click=""toggle"">
                <!-- <span v-if=""isFolder"">[{{ isOpen ? '-' : '+' }}]</span> -->
                <i class=""fas fa-folder""> </i>
                {{ item.Name }}                    
            </a>
            <div class=""sub-folders"" 
                v-show=""isOpen"" v-if=""isFolder"">
                <tree-item
                    v-for=""(child, index) in item.Subfolders""
                    :key=""index""
                    :item=""child"">
                </tree-item>
            </div>
            <div class=""md-file"" 
                v-show=""isOpen""
                v-for=""(file, index) in item.Files""
                v-on:click=""fetchMarkdown(file.NormalizedPath)"">
                
                <a> <i class=""fas fa-file""> </i> {{file.Name}}</a>
            </div>
        </div>
   ");
                WriteLiteral(@" </script>

    <style>
        .root-folder{
            margin-left: -1em;
        }
        .root-folder .sub-folders{
            margin-bottom: 10px;
        }
        .md-folder{
            margin-left: 1em;
        }
        .md-folder > a{
            font-size: 1.2em;
            font-weight: bold;
        }
        .md-folder > .md-file{
            margin-left: 1.2em;            
        }
    </style>

    <script>
    $( document ).ready(function() {

        function escapeRegExp(str) {
            return str.replace(/([.*+?^=!:${}()|\[\]\/\\])/g, ""\\$1"");
        }

        function replaceAll(str, find, replace) {
            return str.replace(new RegExp(escapeRegExp(find), 'g'), replace);
        }

        function santizeMarkdown(str)
        {
            let sanitizedString = str.replace(new RegExp(escapeRegExp('&gt;'), 'g'), '>');            
            sanitizedString = sanitizedString.replace(new RegExp(escapeRegExp('&lt;'), 'g'), '<');
          ");
                WriteLiteral(@"  return sanitizedString;
        }

        showdown.extension('bootstrap-tables', function () {
            return [{
                type: ""output"",
                filter: function (html, converter, options) {
                // parse the html string
                var liveHtml = $('<div></div>').html(html);
                $('table', liveHtml).each(function(){ 
                    var table = $(this);
                    // table bootstrap classes
                    table.addClass('table table-striped table-bordered')
                    // make table responsive
                    //.wrap('<div class=""class table-responsive""></div>');
                });
                return liveHtml.html();
                }
            }];
        });

        // EVENT HUB
        window.eventHub = new Vue({
            methods:{
               fetchMarkdown(path){  
                    this.$emit('fetch-markdown', path);
                } 
            }
        });

        // define");
                WriteLiteral(@" the tree-item component
        Vue.component('tree-item', {
            template: '#item-template',
            props: {
                item: Object,
            },
            data: function () {
                return {
                    isOpen: false,
                    editing: false,
                    filePath: """",
                    doc: """",
                }
            },
            computed: {
                isFolder: function () {
                    return this.item.Files &&
                        this.item.Files.length
                }
            },
            methods: {
                toggle: function () {
                    if (this.isFolder) {
                        this.isOpen = !this.isOpen
                    }
                },
                fetchMarkdown(path){  
                    window.eventHub.fetchMarkdown(path);
                },
            }
        });

        var app = new Vue({
            el: '#app',
            data: {");
                WriteLiteral("\n                searchPattern: \'\',\r\n                searchResults: [ ],\r\n                simplemde: null,\r\n                editing: false,\r\n                filePath: \"\",\r\n                document: \"\",\r\n                rootFolder: ");
                EndContext();
                BeginContext(6504, 103, false);
#line 182 "c:\Projects\KnowledgeBase\Views\KnowledgeBase\Index.cshtml"
                       Write(Html.Raw(Newtonsoft.Json.JsonConvert.SerializeObject(@rootFolder, Newtonsoft.Json.Formatting.Indented)));

#line default
#line hidden
                EndContext();
                BeginContext(6607, 5543, true);
                WriteLiteral(@"
            },
            methods:{
                OpenSubfolder(folder){
                    console.log(folder);
                },
                addItem: function () {
                    console.log(""AddItem"");
                },
                fetchMarkdown(path){ 
                    var self = this;  
                    if(self.editing == true)
                        return;

                    self.filePath = path;   
                    self.document = document.getElementById(""document"").innerHTML;             
                    axios({
                        method: 'post',
                        url: '/KnowledgeBase/FetchMarkdown',
                        data: {
                            file: self.filePath,
                            document: self.document
                        }
                    })
                    .then(function (response) {
                        var converter = new showdown.Converter({ extensions: ['bootstrap-tables'] });
  ");
                WriteLiteral(@"                      converter.setOption('tables', 'true');                        
                        converter.setOption('parseImgDimensions', 'true');
                        let htmlText = converter.makeHtml(response.data);
                        document.getElementById('MDTextArea').innerHTML = response.data;
                        document.getElementById('markdown-content').innerHTML = htmlText;
                    })
                    .catch(function (error) {
                        console.log(error);
                    });
                },
                SearchMarkdown(doc){
                    var self = this;
                    axios({
                        method: 'post',
                        url: '/KnowledgeBase/SearchMarkdown',
                        data: {
                            searchPattern: this.searchPattern,
                            document: doc
                        }
                    })
                    .then(response => {
    ");
                WriteLiteral(@"                    self.searchResults = [];
                        if(Array.isArray(response.data))
                        {
                            response.data.forEach(function (item, index) {
                                self.searchResults.push(item);
                            });
                        }
                        console.log(self.searchResults);
                    })
                    .catch(function (error) {
                        console.log(error);
                    });
                },
                ClearSearch(){
                    this.searchResults = [];
                    this.searchPattern = """";
                },
                StartEdit(){
                    this.editing = true;
                    if(this.simplemde == null)
                    {
                        this.simplemde = new SimpleMDE({ element: document.getElementById(""MDTextArea"") });
                        let sanitizedString = santizeMarkdown(document.getElem");
                WriteLiteral(@"entById('MDTextArea').innerHTML);
                        this.simplemde.value(sanitizedString);
                    }                    
                },                
                SaveEdit(){
                    this.editing = false;
                    if(this.simplemde != null)
                    {
                        var converter = new showdown.Converter();
                        converter.setOption('tables', 'true');
                        converter.setOption('parseImgDimensions', 'true');
                        let htmlText = converter.makeHtml(this.simplemde.value());                        
                        document.getElementById('MDTextArea').innerHTML = this.simplemde.value();
                        document.getElementById('markdown-content').innerHTML = htmlText;

                        axios({
                            method: 'post',
                            url: '/KnowledgeBase/SaveMarkdown',
                            data: {
                ");
                WriteLiteral(@"                file: this.filePath,
                                document: this.document,
                                markdown: this.simplemde.value(),
                            }
                        })

                        this.simplemde.toTextArea();
                        this.simplemde = null;                        
                    } 

                    
                },
                CancelEdit(){
                    this.editing = false;
                    if(this.simplemde != null)
                    {
                        this.simplemde.toTextArea();
                        this.simplemde = null; 
                    }
                },
                HtmlToPdf(){
                     //let htmlString = document.getElementById('markdown-content').innerHTML;
                     let htmlString = document.documentElement.innerHTML
                     axios({
                            method: 'post',
                            url: '/Knowl");
                WriteLiteral(@"edgeBase/CreatePdf',
                            data: {
                                html: htmlString,
                            }
                        })
                }
            },
            created(){
                window.eventHub.$on(""fetch-markdown"", (path) => {
                    this.fetchMarkdown(path);
                })
            }
        })
        
    });
    </script>
");
                EndContext();
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
