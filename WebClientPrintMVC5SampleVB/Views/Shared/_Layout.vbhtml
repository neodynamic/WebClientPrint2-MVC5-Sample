<!DOCTYPE html>
<html>
<head>
    <title>@ViewData("Title")</title>

    <!--[if lt IE 9]>
        <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
    <![endif]-->
    <link href="http://netdna.bootstrapcdn.com/twitter-bootstrap/2.1.1/css/bootstrap.min.css" rel="stylesheet">
    <!--[if IE 6]>
        <link href="https://raw.github.com/empowering-communities/Bootstrap-IE6/master/ie6.min.css" rel="stylesheet">
    <![endif]-->

    <style type="text/css">
        body {
            padding-top: 20px;
            padding-bottom: 40px;
        }

        .container-narrow {
            margin: 0 auto;
            max-width: 700px;
        }

            .container-narrow > hr {
                margin: 15px 0;
            }
    </style>

    @If (IsSectionDefined("MyHead")) Then

        @RenderSection("MyHead")

    End If

</head>

<body>
    <div class="container-narrow">

        <div class="masthead">
            <ul class="nav nav-pills pull-right">
                <li><a href="@Url.Action("samples", "home")"><i class="icon-home"></i></a></li>
                <li><a href="@Url.Action("index", "DemoPrintCommands")">Print Commands</a></li>
                <li><a href="@Url.Action("index", "DemoPrintFile")">Print Files</a></li>
            </ul>
            <h3 class="muted"><a href="http://www.neodynamic.com/products/printing/raw-data/aspnet-mvc/" target="_blank">WebClientPrint 2.0 for ASP.NET</a></h3>
            <small><em>Cross-browser Client-side Printing Solution for Windows, Linux &amp; Mac</em></small>
        </div>
        <div class="pull-right">
            <a class="btn btn-primary" href="http://www.neodynamic.com/products/printing/raw-data/aspnet-mvc/download/" target="_blank"><i class="icon-download-alt icon-white"></i> Download SDK for ASP.NET</a>
        </div>
        <hr>

        <div>
            @RenderBody()
        </div>

        <div class="footer">
            <br /><br /><br /><br /><hr />
            <p>
                <a href="http://www.neodynamic.com/products/printing/raw-data/aspnet-mvc/" target="_blank">WebClientPrint for ASP.NET</a>
                &nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
                <i class="icon-user"></i> <a href="http://www.neodynamic.com/spport" target="_blank">Contact Tech Support</a>
            </p>
            <p>&copy; Copyright 2013 - Neodynamic SRL<br />All rights reserved.</p>
        </div>

    </div> <!-- /container -->




    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
    <script src="http://netdna.bootstrapcdn.com/twitter-bootstrap/2.1.1/js/bootstrap.min.js"></script>
    <script type="text/javascript">
        $(function () {
            if ($.browser.msie && parseInt($.browser.version, 10) === 6) { $('.row div[class^="span"]:last-child').addClass("last-child"); $('[class*="span"]').addClass("margin-left-20"); $('[class*="span"][class*="offset"]').removeClass('margin-left-20'); $(':button[class="btn"], :reset[class="btn"], :submit[class="btn"], input[type="button"]').addClass("button-reset"); $(":checkbox").addClass("input-checkbox"); $('[class^="icon-"], [class*=" icon-"]').addClass("icon-sprite"); $(".pagination li:first-child a").addClass("pagination-first-child") }
        });</script>


    @If (IsSectionDefined("MyScript")) Then

        @RenderSection("MyScript")

    End If
</body>
</html>
