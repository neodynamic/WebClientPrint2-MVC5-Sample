@Code
    ViewData("Title") = "Print File"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

@* Store User's SessionId *@
<input type="hidden" id="sid" name="sid" value="@Session.SessionID" />

<div class="container">

    <div class="row">
        <div class="span9">
            <h3>Print File without displaying any Print dialog! <small>(if needed)</small></h3>
            <p>
                With <strong>WebClientPrint for ASP.NET</strong> you can <strong>print most common file formats</strong> <em>(PDF, TXT, DOC/X, XLS/X, JPG/JPEG, PNG, TIF/TIFF)</em> right to any installed printer at the client side.
            </p>
            <div class="accordion" id="accordion1">
                <div class="accordion-group">
                    <div class="accordion-heading">
                        <h4>
                            <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion1" href="#collapse1">
                                Client System Requirements
                            </a>
                        </h4>
                    </div>
                    <div id="collapse1" class="accordion-body collapse">
                        <div class="accordion-inner">
                            <table class="table table-bordered">
                                <thead>
                                    <tr style="background-color:#ececec; font-weight:bold;color:#666">
                                        <td style="width:20%">&nbsp;</td>
                                        <td style="width:40%">Windows Clients</td>
                                        <td style="width:40%">Linux &amp; Mac Clients</td>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>DOC, DOCX</td>
                                        <td><span class="badge badge-warning"><i class="icon-info-sign icon-white"></i></span> Microsoft Word is required</td>
                                        <td><span class="badge badge-warning"><i class="icon-info-sign icon-white"></i></span> LibreOffice is required</td>
                                    </tr>
                                    <tr>
                                        <td>XLS, XLSX</td>
                                        <td><span class="badge badge-warning"><i class="icon-info-sign icon-white"></i></span> Microsoft Excel is required</td>
                                        <td><span class="badge badge-warning"><i class="icon-info-sign icon-white"></i></span> LibreOffice is required</td>
                                    </tr>
                                    <tr>
                                        <td>PDF</td>
                                        <td><span class="badge badge-warning"><i class="icon-info-sign icon-white"></i></span> Adobe Acrobat or Foxit Reader is required</td>
                                        <td><span class="badge badge-success"><i class="icon-ok-sign icon-white"></i></span> Natively supported!</td>
                                    </tr>
                                    <tr>
                                        <td>TXT</td>
                                        <td><span class="badge badge-warning"><i class="icon-info-sign icon-white"></i></span> Notepad is required</td>
                                        <td><span class="badge badge-success"><i class="icon-ok-sign icon-white"></i></span> Natively supported!</td>
                                    </tr>
                                    <tr>
                                        <td>JPEG</td>
                                        <td><span class="badge badge-success"><i class="icon-ok-sign icon-white"></i></span> Natively supported!</td>
                                        <td><span class="badge badge-success"><i class="icon-ok-sign icon-white"></i></span> Natively supported!</td>
                                    </tr>
                                    <tr>
                                        <td>PNG</td>
                                        <td><span class="badge badge-success"><i class="icon-ok-sign icon-white"></i></span> Natively supported!</td>
                                        <td><span class="badge badge-success"><i class="icon-ok-sign icon-white"></i></span> Natively supported!</td>
                                    </tr>
                                    <tr>
                                        <td>BMP</td>
                                        <td><span class="badge badge-success"><i class="icon-ok-sign icon-white"></i></span> Natively supported!</td>
                                        <td><span class="badge badge-success"><i class="icon-ok-sign icon-white"></i></span> Natively supported!</td>
                                    </tr>
                                    <tr>
                                        <td>Printer Support</td>
                                        <td><span class="badge badge-warning"><i class="icon-info-sign icon-white"></i></span> You can print files to local installed printers ONLY! Parallel, Serial and IP/Ethernet printers are NOT supported.</td>
                                        <td><span class="badge badge-success"><i class="icon-ok-sign icon-white"></i></span> You can print files to any installed printers through CUPS system.</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="accordion-group">
                    <div class="accordion-heading">
                        <h4>
                            <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion1" href="#collapse2">
                                Test it!
                            </a>
                        </h4>
                    </div>
                    <div id="collapse2" class="accordion-body collapse">
                        <div class="accordion-inner">
                            <p>
                                The following are pre-selected files to test WebClientPrint File Printing feature.
                            </p>
                            <div class="row">
                                <div class="span4">
                                    <hr />
                                    <label class="checkbox">
                                        <input type="checkbox" id="useDefaultPrinter" /> <strong>Print to Default printer</strong> or...
                                    </label>
                                    <div id="loadPrinters">
                                        Click to load and select one of the installed printers!
                                        <br />
                                        <a onclick="javascript:jsWebClientPrint.getPrinters();" class="btn btn-success">Load installed printers...</a>

                                        <br /><br />
                                    </div>
                                    <div id="installedPrinters" style="visibility:hidden">
                                        <label for="installedPrinterName">Select an installed Printer:</label>
                                        <select name="installedPrinterName" id="installedPrinterName"></select>
                                    </div>

                                    <script type="text/javascript">
                                        var wcppGetPrintersDelay_ms = 5000; //5 sec

                                        function wcpGetPrintersOnSuccess(){
                                            @* Display client installed printers *@
                                            if(arguments[0].length > 0){
                                                var p=arguments[0].split("|");
                                                var options = '';
                                                for (var i = 0; i < p.length; i++) {
                                                    options += '<option>' + p[i] + '</option>';
                                                }
                                                $('#installedPrinters').css('visibility','visible');
                                                $('#installedPrinterName').html(options);
                                                $('#installedPrinterName').focus();
                                                $('#loadPrinters').hide();
                                            }else{
                                                alert("No printers are installed in your system.");
                                        }
                                        }

                                        function wcpGetPrintersOnFailure() {
                                            @* Do something if printers cannot be got from the client *@
                                            alert("No printers are installed in your system.");
                                        }
                                    </script>


                                </div>
                                <div class="span4">
                                    <hr />
                                    <div id="fileToPrint">
                                        <label for="ddlFileType">Select a sample File to print:</label>
                                        <select id="ddlFileType">
                                            <option>PDF</option>
                                            <option>TXT</option>
                                            <option>DOC</option>
                                            <option>XLS</option>
                                            <option>JPG</option>
                                            <option>PNG</option>
                                            <option>TIF</option>
                                        </select>

                                        <br />
                                        <a class="btn btn-info btn-large" onclick="javascript:jsWebClientPrint.print('useDefaultPrinter=' + $('#useDefaultPrinter').attr('checked') + '&printerName=' + $('#installedPrinterName').val() + '&filetype=' + $('#ddlFileType').val());">Print File...</a>

                                    </div>
                                </div>
                            </div>
                            <h5>File Preview</h5>
                            <iframe id="ifPreview" style="width:100%; height:500px;" frameborder="0"></iframe>
                        </div>

                    </div>
                </div>
            </div>

        </div>




    </div>
</div>


@section MyScript

    @* Register the WebClientPrint script code. The param is the URL for the PrintFile method in the DemoPrintFileController. *@
    @Html.Raw(Neodynamic.SDK.Web.WebClientPrint.CreateScript(Url.Action("PrintFile", "DemoPrintFile", Nothing, Request.Url.Scheme)))

    <script type="text/javascript">
        $("#ddlFileType").change(function () {
            var s = $("#ddlFileType option:selected").text();
            if (s == 'DOC') $("#ifPreview").attr("src", "http://docs.google.com/gview?url=http://webclientprint.azurewebsites.net/files/LoremIpsum.doc&embedded=true");
            if (s == 'PDF') $("#ifPreview").attr("src", "http://docs.google.com/gview?url=http://webclientprint.azurewebsites.net/files/LoremIpsum.pdf&embedded=true");
            if (s == 'TXT') $("#ifPreview").attr("src", "http://docs.google.com/gview?url=http://webclientprint.azurewebsites.net/files/LoremIpsum.txt&embedded=true");
            if (s == 'TIF') $("#ifPreview").attr("src", "http://docs.google.com/gview?url=http://webclientprint.azurewebsites.net/files/patent2pages.tif&embedded=true");
            if (s == 'XLS') $("#ifPreview").attr("src", "http://docs.google.com/gview?url=http://webclientprint.azurewebsites.net/files/SampleSheet.xls&embedded=true");
            if (s == 'JPG') $("#ifPreview").attr("src", "http://webclientprint.azurewebsites.net/files/penguins300dpi.jpg");
            if (s == 'PNG') $("#ifPreview").attr("src", "http://webclientprint.azurewebsites.net/files/SamplePngImage.png");
        }).change();
    </script>
end section

