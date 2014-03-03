Imports System.Web.Mvc

Imports Neodynamic.SDK.Web

Public Class DemoPrintFileController
    Inherits Controller

    ' GET: /DemoPrintFile
    Function Index() As ActionResult
        Return View()
    End Function

    Public Sub PrintFile(useDefaultPrinter As String, printerName As String, fileType As String)

        Dim fileName As String = Guid.NewGuid().ToString("N") + "." + fileType
        Dim filePath As String = Nothing
        Select Case fileType

            Case "PDF"
                filePath = "~/files/LoremIpsum.pdf"

            Case "TXT"
                filePath = "~/files/LoremIpsum.txt"

            Case "DOC"
                filePath = "~/files/LoremIpsum.doc"

            Case "XLS"
                filePath = "~/files/SampleSheet.xls"

            Case "JPG"
                filePath = "~/files/penguins300dpi.jpg"

            Case "PNG"
                filePath = "~/files/SamplePngImage.png"

            Case "TIF"
                filePath = "~/files/patent2pages.tif"

        End Select


        If (filePath <> Nothing) Then

            Dim file As New PrintFile(System.Web.HttpContext.Current.Server.MapPath(filePath), fileName)
            Dim cpj As New ClientPrintJob()
            cpj.PrintFile = file
            If (useDefaultPrinter = "checked" OrElse printerName = "null") Then
                cpj.ClientPrinter = New DefaultPrinter()
            Else
                cpj.ClientPrinter = New InstalledPrinter(System.Web.HttpUtility.UrlDecode(printerName))
            End If
            cpj.SendToClient(System.Web.HttpContext.Current.Response)

        End If


    End Sub


End Class