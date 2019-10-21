
var cuerpoword = "";

document.getElementById('btnContato').onclick = function () {

    cuerpoword = document.getElementById('txtWord').innerHTML;

    var pdf = "<html><head><meta charset='utf-8'></head><body>"
        + cuerpoword
        + "</body></html>";


    var blob = new Blob([pdf], { type: 'application/pdf' });
        if (navigator.appVersion.toString().indexOf('.NET') > 0) {
            window.navigator.msSaveBlob(blob, "listadomembresias.pdf");
        } else {
            this.download = "listadomembresias.pdf";
            this.href = window.URL.createObjectURL(blob);
    }

    if (document.getElementById('cbagree2').checked == true) {


        
        //var static = {
        //    mhtml: {
        //        top: "Mime-Version: 1.0\nContent-Base: " + location.href + "\nContent-Type: Multipart/related; boundary=\"NEXT.ITEM-BOUNDARY\";type=\"text/html\"\n\n--NEXT.ITEM-BOUNDARY\nContent-Type: text/html; charset=\"utf-8\"\nContent-Location: "
        //            + location.href + "\n\n<!DOCTYPE html>\n<html "
        //            + "xmlns:v='urn: schemas - microsoft - com: vml'"
        //            + "xmlns:o = 'urn:schemas-microsoft-com:office:office'"
        //            + "xmlns:w = 'urn:schemas-microsoft-com:office:word'"
        //            + "xmlns:m = 'http://schemas.microsoft.com/office/2004/12/omml'"
        //            + "xmlns='http://www.w3.org/TR/REC-html40'"
        //            + " xmlns:w='urn:schemas-microsoft-com:office:word' "
        //            + " xmlns:m='http://schemas.microsoft.com/office/2004/12/omml'"
        //            + " xmlns='http://www.w3.org/TR/REC-html40' >\n_html_</html>",
        //        head: "<head>\n<meta http-equiv=Content-Type content='text/html>"
        //            + " <meta charset='utf-8'>"
        //            + " <meta name=ProgId content=Word.Document>"
        //            + " <meta name=Generator content='Microsoft Word 15'>"
        //            + " <meta name=Originator content='Microsoft Word 15'>"
        //            + " <link rel=File-List href='ContractIs_archivos/filelist.xml'>"
        //            + " <link rel=Edit-Time-Data href='ContractIs_archivos/editdata.mso'>"
        //            + " <link rel=themeData href='ContractIs_archivos/themedata.thmx'>"
        //            + " <link rel=colorSchemeMapping href='ContractIs_archivos/colorschememapping.xml'>"
        //            + "\n<style>\n_styles_\n</style>\n</head>\n",
        //        body: "<body lang=EN-US style='tab-interval:35.4pt' >"
        //            + cuerpoword
        //            + "_body_</body>"
        //    }
        //};
        //var options = {
        //    maxWidth: 624
        //};
        //// Clone selected element before manipulating it
        //var markup = $(this).clone();

        //// Remove hidden elements from the output
        //markup.each(function () {
        //    var self = $(this);
        //    if (self.is(':hidden'))
        //        self.remove();
        //});

        //// Embed all images using Data URLs
        //var images = Array();
        //var img = markup.find('img');
        //for (var i = 0; i < img.length; i++) {
        //    // Calculate dimensions of output image
        //    var w = Math.min(img[i].width, options.maxWidth);
        //    var h = img[i].height * (w / img[i].width);
        //    // Create canvas for converting image to data URL
        //    var canvas = document.createElement("CANVAS");
        //    canvas.width = w;
        //    canvas.height = h;
        //    // Draw image to canvas
        //    var context = canvas.getContext('2d');
        //    context.drawImage(img[i], 0, 0, w, h);
        //    // Get data URL encoding of image
        //    var uri = canvas.toDataURL("image/png");
        //    $(img[i]).attr("src", img[i].src);
        //    img[i].width = w;
        //    img[i].height = h;
        //    // Save encoded image to array
        //    images[i] = {
        //        type: uri.substring(uri.indexOf(":") + 1, uri.indexOf(";")),
        //        encoding: uri.substring(uri.indexOf(";") + 1, uri.indexOf(",")),
        //        location: $(img[i]).attr("src"),
        //        data: uri.substring(uri.indexOf(",") + 1)
        //    };
        //}

        //// Prepare bottom of mhtml file with image data
        //var mhtmlBottom = "\n";
        //for (var i = 0; i < images.length; i++) {
        //    mhtmlBottom += "--NEXT.ITEM-BOUNDARY\n";
        //    mhtmlBottom += "Content-Location: " + images[i].location + "\n";
        //    mhtmlBottom += "Content-Type: " + images[i].type + "\n";
        //    mhtmlBottom += "Content-Transfer-Encoding: " + images[i].encoding + "\n\n";
        //    mhtmlBottom += images[i].data + "\n\n";
        //}
        //mhtmlBottom += "--NEXT.ITEM-BOUNDARY--";

        ////TODO: load css from included stylesheet
        //var styles = " @font-face"
        //    + "	{font-family:Wingdings;"
        //    + "	panose-1:5 0 0 0 0 0 0 0 0 0;"
        //    + "	mso-font-charset:2;"
        //    + "	mso-generic-font-family:auto;"
        //    + "	mso-font-pitch:variable;"
        //    + "	mso-font-signature:0 268435456 0 0 -2147483648 0;}"
        //    + "@font-face"
        //    + "	{font-family:'Cambria Math';"
        //    + "	panose-1:2 4 5 3 5 4 6 3 2 4;"
        //    + "	mso-font-charset:1;"
        //    + "	mso-generic-font-family:roman;"
        //    + "	mso-font-pitch:variable;"
        //    + "	mso-font-signature:0 0 0 0 0 0;}"
        //    + "@font-face"
        //    + "	{font-family:Calibri;"
        //    + "	panose-1:2 15 5 2 2 2 4 3 2 4;"
        //    + "	mso-font-charset:0;"
        //    + "	mso-generic-font-family:swiss;"
        //    + "	mso-font-pitch:variable;"
        //    + "	mso-font-signature:-536859905 -1073732485 9 0 511 0;}"
        //    + "@font-face"
        //    + "	{font-family:'Segoe UI';"
        //    + "	panose-1:2 11 5 2 4 2 4 2 2 3;"
        //    + "	mso-font-charset:0;"
        //    + "	mso-generic-font-family:swiss;"
        //    + "	mso-font-pitch:variable;"
        //    + "	mso-font-signature:-469750017 -1073683329 9 0 511 0;}"
        //    + " /* Style Definitions */"
        //    + " p.MsoNormal, li.MsoNormal, div.MsoNormal"
        //    + "	{mso-style-unhide:no;"
        //    + "	mso-style-qformat:yes;"
        //    + "	mso-style-parent:'';"
        //    + "	margin-top:0cm;"
        //    + "	margin-right:0cm;"
        //    + "	margin-bottom:8.0pt;"
        //    + "	margin-left:0cm;"
        //    + "	line-height:107%;"
        //    + "	mso-pagination:widow-orphan;"
        //    + "	font-size:11.0pt;"
        //    + "	font-family:'Calibri',sans-serif;"
        //    + "	mso-ascii-font-family:Calibri;"
        //    + "	mso-ascii-theme-font:minor-latin;"
        //    + "	mso-fareast-font-family:Calibri;"
        //    + "	mso-fareast-theme-font:minor-latin;"
        //    + "	mso-hansi-font-family:Calibri;"
        //    + "	mso-hansi-theme-font:minor-latin;"
        //    + "	mso-bidi-font-family:'Times New Roman';"
        //    + "	mso-bidi-theme-font:minor-bidi;"
        //    + "	mso-ansi-language:ES-PE;}"
        //    + "p.MsoHeader, li.MsoHeader, div.MsoHeader"
        //    + "	{mso-style-priority:99;"
        //    + "	mso-style-link:'Encabezado Car';"
        //    + "	margin:0cm;"
        //    + "	margin-bottom:.0001pt;"
        //    + "	mso-pagination:widow-orphan;"
        //    + "	tab-stops:center 225.65pt right 451.3pt;"
        //    + "	font-size:11.0pt;"
        //    + "	font-family:'Calibri',sans-serif;"
        //    + "	mso-ascii-font-family:Calibri;"
        //    + "	mso-ascii-theme-font:minor-latin;"
        //    + "	mso-fareast-font-family:Calibri;"
        //    + "	mso-fareast-theme-font:minor-latin;"
        //    + "	mso-hansi-font-family:Calibri;"
        //    + "	mso-hansi-theme-font:minor-latin;"
        //    + "	mso-bidi-font-family:'Times New Roman';"
        //    + "	mso-bidi-theme-font:minor-bidi;"
        //    + "	mso-ansi-language:ES-PE;}"
        //    + "p.MsoFooter, li.MsoFooter, div.MsoFooter"
        //    + "	{mso-style-priority:99;"
        //    + "	mso-style-link:'Pie de página Car';"
        //    + "	margin:0cm;"
        //    + "	margin-bottom:.0001pt;"
        //    + "	mso-pagination:widow-orphan;"
        //    + "	tab-stops:center 225.65pt right 451.3pt;"
        //    + "	font-size:11.0pt;"
        //    + "	font-family:'Calibri',sans-serif;"
        //    + "	mso-ascii-font-family:Calibri;"
        //    + "	mso-ascii-theme-font:minor-latin;"
        //    + "	mso-fareast-font-family:Calibri;"
        //    + "	mso-fareast-theme-font:minor-latin;"
        //    + "	mso-hansi-font-family:Calibri;"
        //    + "	mso-hansi-theme-font:minor-latin;"
        //    + "	mso-bidi-font-family:'Times New Roman';"
        //    + "	mso-bidi-theme-font:minor-bidi;"
        //    + "	mso-ansi-language:ES-PE;}"
        //    + "p.MsoAcetate, li.MsoAcetate, div.MsoAcetate"
        //    + "	{mso-style-noshow:yes;"
        //    + "	mso-style-priority:99;"
        //    + "	mso-style-link:'Texto de globo Car';"
        //    + "	margin:0cm;"
        //    + "	margin-bottom:.0001pt;"
        //    + "	mso-pagination:widow-orphan;"
        //    + "	font-size:9.0pt;"
        //    + "	font-family:'Segoe UI',sans-serif;"
        //    + "	mso-fareast-font-family:Calibri;"
        //    + "	mso-fareast-theme-font:minor-latin;"
        //    + "	mso-ansi-language:ES-PE;}"
        //    + "p.MsoListParagraph, li.MsoListParagraph, div.MsoListParagraph"
        //    + "	{mso-style-priority:34;"
        //    + "	mso-style-unhide:no;"
        //    + "	mso-style-qformat:yes;"
        //    + "	margin-top:0cm;"
        //    + "	margin-right:0cm;"
        //    + "	margin-bottom:8.0pt;"
        //    + "	margin-left:36.0pt;"
        //    + "	mso-add-space:auto;"
        //    + "	line-height:107%;"
        //    + "	mso-pagination:widow-orphan;"
        //    + "	font-size:11.0pt;"
        //    + "	font-family:'Calibri',sans-serif;"
        //    + "	mso-ascii-font-family:Calibri;"
        //    + "	mso-ascii-theme-font:minor-latin;"
        //    + "	mso-fareast-font-family:Calibri;"
        //    + "	mso-fareast-theme-font:minor-latin;"
        //    + "	mso-hansi-font-family:Calibri;"
        //    + "	mso-hansi-theme-font:minor-latin;"
        //    + "	mso-bidi-font-family:'Times New Roman';"
        //    + "	mso-bidi-theme-font:minor-bidi;"
        //    + "	mso-ansi-language:ES-PE;}"
        //    + "p.MsoListParagraphCxSpFirst, li.MsoListParagraphCxSpFirst, div.MsoListParagraphCxSpFirst"
        //    + "	{mso-style-priority:34;"
        //    + "	mso-style-unhide:no;"
        //    + "	mso-style-qformat:yes;"
        //    + "	mso-style-type:export-only;"
        //    + "	margin-top:0cm;"
        //    + "	margin-right:0cm;"
        //    + "	margin-bottom:0cm;"
        //    + "	margin-left:36.0pt;"
        //    + "	margin-bottom:.0001pt;"
        //    + "	mso-add-space:auto;"
        //    + "	line-height:107%;"
        //    + "	mso-pagination:widow-orphan;"
        //    + "	font-size:11.0pt;"
        //    + "	font-family:'Calibri',sans-serif;"
        //    + "	mso-ascii-font-family:Calibri;"
        //    + "	mso-ascii-theme-font:minor-latin;"
        //    + "	mso-fareast-font-family:Calibri;"
        //    + "	mso-fareast-theme-font:minor-latin;"
        //    + "	mso-hansi-font-family:Calibri;"
        //    + "	mso-hansi-theme-font:minor-latin;"
        //    + "	mso-bidi-font-family:'Times New Roman';"
        //    + "	mso-bidi-theme-font:minor-bidi;"
        //    + "	mso-ansi-language:ES-PE;}"
        //    + "p.MsoListParagraphCxSpMiddle, li.MsoListParagraphCxSpMiddle, div.MsoListParagraphCxSpMiddle"
        //    + "	{mso-style-priority:34;"
        //    + "	mso-style-unhide:no;"
        //    + "	mso-style-qformat:yes;"
        //    + "	mso-style-type:export-only;"
        //    + "	margin-top:0cm;"
        //    + "	margin-right:0cm;"
        //    + "	margin-bottom:0cm;"
        //    + "	margin-left:36.0pt;"
        //    + "	margin-bottom:.0001pt;"
        //    + "	mso-add-space:auto;"
        //    + "	line-height:107%;"
        //    + "	mso-pagination:widow-orphan;"
        //    + "	font-size:11.0pt;"
        //    + "	font-family:'Calibri',sans-serif;"
        //    + "	mso-ascii-font-family:Calibri;"
        //    + "	mso-ascii-theme-font:minor-latin;"
        //    + "	mso-fareast-font-family:Calibri;"
        //    + "	mso-fareast-theme-font:minor-latin;"
        //    + "	mso-hansi-font-family:Calibri;"
        //    + "	mso-hansi-theme-font:minor-latin;"
        //    + "	mso-bidi-font-family:'Times New Roman';"
        //    + "	mso-bidi-theme-font:minor-bidi;"
        //    + "	mso-ansi-language:ES-PE;}"
        //    + "p.MsoListParagraphCxSpLast, li.MsoListParagraphCxSpLast, div.MsoListParagraphCxSpLast"
        //    + "	{mso-style-priority:34;"
        //    + "	mso-style-unhide:no;"
        //    + "	mso-style-qformat:yes;"
        //    + "	mso-style-type:export-only;"
        //    + "	margin-top:0cm;"
        //    + "	margin-right:0cm;"
        //    + "	margin-bottom:8.0pt;"
        //    + "	margin-left:36.0pt;"
        //    + "	mso-add-space:auto;"
        //    + "	line-height:107%;"
        //    + "	mso-pagination:widow-orphan;"
        //    + "	font-size:11.0pt;"
        //    + "	font-family:'Calibri',sans-serif;"
        //    + "	mso-ascii-font-family:Calibri;"
        //    + "	mso-ascii-theme-font:minor-latin;"
        //    + "	mso-fareast-font-family:Calibri;"
        //    + "	mso-fareast-theme-font:minor-latin;"
        //    + "	mso-hansi-font-family:Calibri;"
        //    + "	mso-hansi-theme-font:minor-latin;"
        //    + "	mso-bidi-font-family:'Times New Roman';"
        //    + "	mso-bidi-theme-font:minor-bidi;"
        //    + "	mso-ansi-language:ES-PE;}"
        //    + "span.EncabezadoCar"
        //    + "	{mso-style-name:'Encabezado Car';"
        //    + "	mso-style-priority:99;"
        //    + "	mso-style-unhide:no;"
        //    + "	mso-style-locked:yes;"
        //    + "	mso-style-link:Encabezado;}"
        //    + "span.PiedepginaCar"
        //    + "	{mso-style-name:'Pie de página Car';"
        //    + "	mso-style-priority:99;"
        //    + "	mso-style-unhide:no;"
        //    + "	mso-style-locked:yes;"
        //    + "	mso-style-link:'Pie de página';}"
        //    + "span.TextodegloboCar"
        //    + "	{mso-style-name:'Texto de globo Car';"
        //    + "	mso-style-noshow:yes;"
        //    + "	mso-style-priority:99;"
        //    + "	mso-style-unhide:no;"
        //    + "	mso-style-locked:yes;"
        //    + "	mso-style-link:'Texto de globo';"
        //    + "	mso-ansi-font-size:9.0pt;"
        //    + "	mso-bidi-font-size:9.0pt;"
        //    + "	font-family:'Segoe UI',sans-serif;"
        //    + "	mso-ascii-font-family:'Segoe UI';"
        //    + "	mso-hansi-font-family:'Segoe UI';"
        //    + "	mso-bidi-font-family:'Segoe UI';}"
        //    + ".MsoChpDefault"
        //    + "	{mso-style-type:export-only;"
        //    + "	mso-default-props:yes;"
        //    + "	font-family:'Calibri',sans-serif;"
        //    + "	mso-ascii-font-family:Calibri;"
        //    + "	mso-ascii-theme-font:minor-latin;"
        //    + "	mso-fareast-font-family:Calibri;"
        //    + "	mso-fareast-theme-font:minor-latin;"
        //    + "	mso-hansi-font-family:Calibri;"
        //    + "	mso-hansi-theme-font:minor-latin;"
        //    + "	mso-bidi-font-family:'Times New Roman';"
        //    + "	mso-bidi-theme-font:minor-bidi;"
        //    + "	mso-ansi-language:ES-PE;}"
        //    + ".MsoPapDefault"
        //    + "	{mso-style-type:export-only;"
        //    + "	margin-bottom:8.0pt;"
        //    + "	line-height:107%;}"
        //    + " /* Page Definitions */"
        //    + " @page"
        //    + "	{mso-footnote-separator:url('ContractIs_archivos / header.htm') fs;"
        //    + "	mso-footnote-continuation-separator:url('ContractIs_archivos / header.htm') fcs;"
        //    + "	mso-endnote-separator:url('ContractIs_archivos / header.htm') es;"
        //    + "	mso-endnote-continuation-separator:url('ContractIs_archivos / header.htm') ecs;}"
        //    + "@page WordSection1"
        //    + "	{size:595.3pt 841.9pt;"
        //    + "	margin:36.0pt 36.0pt 21.3pt 36.0pt;"
        //    + "	mso-header-margin:14.2pt;"
        //    + "	mso-footer-margin:6.9pt;"
        //    + "	mso-even-header:url('ContractIs_archivos / header.htm') eh1;"
        //    + "	mso-header:url('ContractIs_archivos / header.htm') h1;"
        //    + "	mso-footer:url('ContractIs_archivos / header.htm') f1;"
        //    + "	mso-first-header:url('ContractIs_archivos / header.htm) fh1;"
        //    + "	mso-paper-source:0;}"
        //    + "div.WordSection1"
        //    + "	{page:WordSection1;}"
        //    + " /* List Definitions */"
        //    + " @list l0"
        //    + "	{mso-list-id:764613839;"
        //    + "	mso-list-type:hybrid;"
        //    + "	mso-list-template-ids:-1714497338 2024294848 671744003 671744005 671744001 671744003 671744005 671744001 671744003 671744005;}"
        //    + "@list l0:level1"
        //    + "	{mso-level-start-at:7;"
        //    + "	mso-level-number-format:bullet;"
        //    + "	mso-level-text:-;"
        //    + "	mso-level-tab-stop:none;"
        //    + "	mso-level-number-position:left;"
        //    + "	text-indent:-18.0pt;"
        //    + "	font-family:'Calibri',sans-serif;"
        //    + "	mso-fareast-font-family:Calibri;"
        //    + "	mso-fareast-theme-font:minor-latin;}"
        //    + "@list l0:level2"
        //    + "	{mso-level-number-format:bullet;"
        //    + "	mso-level-text:o;"
        //    + "	mso-level-tab-stop:none;"
        //    + "	mso-level-number-position:left;"
        //    + "	text-indent:-18.0pt;"
        //    + "	font-family:'Courier New';}"
        //    + "@list l0:level3"
        //    + "	{mso-level-number-format:bullet;"
        //    + "	mso-level-text:\F0A7;"
        //    + "	mso-level-tab-stop:none;"
        //    + "	mso-level-number-position:left;"
        //    + "	text-indent:-18.0pt;"
        //    + "	font-family:Wingdings;}"
        //    + "@list l0:level4"
        //    + "	{mso-level-number-format:bullet;"
        //    + "	mso-level-text:\F0B7;"
        //    + "	mso-level-tab-stop:none;"
        //    + "	mso-level-number-position:left;"
        //    + "	text-indent:-18.0pt;"
        //    + "	font-family:Symbol;}"
        //    + "@list l0:level5"
        //    + "	{mso-level-number-format:bullet;"
        //    + "	mso-level-text:o;"
        //    + "	mso-level-tab-stop:none;"
        //    + "	mso-level-number-position:left;"
        //    + "	text-indent:-18.0pt;"
        //    + "	font-family:'Courier New';}"
        //    + "@list l0:level6"
        //    + "	{mso-level-number-format:bullet;"
        //    + "	mso-level-text:\F0A7;"
        //    + "	mso-level-tab-stop:none;"
        //    + "	mso-level-number-position:left;"
        //    + "	text-indent:-18.0pt;"
        //    + "	font-family:Wingdings;}"
        //    + "@list l0:level7"
        //    + "	{mso-level-number-format:bullet;"
        //    + "	mso-level-text:\F0B7;"
        //    + "	mso-level-tab-stop:none;"
        //    + "	mso-level-number-position:left;"
        //    + "	text-indent:-18.0pt;"
        //    + "	font-family:Symbol;}"
        //    + "@list l0:level8"
        //    + "	{mso-level-number-format:bullet;"
        //    + "	mso-level-text:o;"
        //    + "	mso-level-tab-stop:none;"
        //    + "	mso-level-number-position:left;"
        //    + "	text-indent:-18.0pt;"
        //    + "	font-family:'Courier New';}"
        //    + "@list l0:level9"
        //    + "	{mso-level-number-format:bullet;"
        //    + "	mso-level-text:\F0A7;"
        //    + "	mso-level-tab-stop:none;"
        //    + "	mso-level-number-position:left;"
        //    + "	text-indent:-18.0pt;"
        //    + "	font-family:Wingdings;}"
        //    + "@list l1"
        //    + "	{mso-list-id:812065131;"
        //    + "	mso-list-type:hybrid;"
        //    + "	mso-list-template-ids:2083269992 1208379228 671744025 671744027 671744015 671744025 671744027 671744015 671744025 671744027;}"
        //    + "@list l1:level1"
        //    + "	{mso-level-number-format:alpha-lower;"
        //    + "	mso-level-text:' % 1\) ';"
        //    + "	mso-level-tab-stop:none;"
        //    + "	mso-level-number-position:left;"
        //    + "	text-indent:-18.0pt;"
        //    + "	mso-ascii-font-family:Calibri;"
        //    + "	mso-ascii-theme-font:minor-latin;"
        //    + "	mso-fareast-font-family:Calibri;"
        //    + "	mso-fareast-theme-font:minor-latin;"
        //    + "	mso-hansi-font-family:Calibri;"
        //    + "	mso-hansi-theme-font:minor-latin;"
        //    + "	mso-bidi-font-family:'Times New Roman';"
        //    + "	mso-bidi-theme-font:minor-bidi;}"
        //    + "@list l1:level2"
        //    + "	{mso-level-number-format:alpha-lower;"
        //    + "	mso-level-tab-stop:none;"
        //    + "	mso-level-number-position:left;"
        //    + "	text-indent:-18.0pt;}"
        //    + "@list l1:level3"
        //    + "	{mso-level-number-format:roman-lower;"
        //    + "	mso-level-tab-stop:none;"
        //    + "	mso-level-number-position:right;"
        //    + "	text-indent:-9.0pt;}"
        //    + "@list l1:level4"
        //    + "	{mso-level-tab-stop:none;"
        //    + "	mso-level-number-position:left;"
        //    + "	text-indent:-18.0pt;}"
        //    + "@list l1:level5"
        //    + "	{mso-level-number-format:alpha-lower;"
        //    + "	mso-level-tab-stop:none;"
        //    + "	mso-level-number-position:left;"
        //    + "	text-indent:-18.0pt;}"
        //    + "@list l1:level6"
        //    + "	{mso-level-number-format:roman-lower;"
        //    + "	mso-level-tab-stop:none;"
        //    + "	mso-level-number-position:right;"
        //    + "	text-indent:-9.0pt;}"
        //    + "@list l1:level7"
        //    + "	{mso-level-tab-stop:none;"
        //    + "	mso-level-number-position:left;"
        //    + "	text-indent:-18.0pt;}"
        //    + "@list l1:level8"
        //    + "	{mso-level-number-format:alpha-lower;"
        //    + "	mso-level-tab-stop:none;"
        //    + "	mso-level-number-position:left;"
        //    + "	text-indent:-18.0pt;}"
        //    + "@list l1:level9"
        //    + "	{mso-level-number-format:roman-lower;"
        //    + "	mso-level-tab-stop:none;"
        //    + "	mso-level-number-position:right;"
        //    + "	text-indent:-9.0pt;}"
        //    + "@list l2"
        //    + "	{mso-list-id:1920359361;"
        //    + "	mso-list-type:hybrid;"
        //    + "	mso-list-template-ids:2083269992 1208379228 671744025 671744027 671744015 671744025 671744027 671744015 671744025 671744027;}"
        //    + "@list l2:level1"
        //    + "	{mso-level-number-format:alpha-lower;"
        //    + "	mso-level-text:' % 1\) ';"
        //    + "	mso-level-tab-stop:none;"
        //    + "	mso-level-number-position:left;"
        //    + "	text-indent:-18.0pt;"
        //    + "	mso-ascii-font-family:Calibri;"
        //    + "	mso-ascii-theme-font:minor-latin;"
        //    + "	mso-fareast-font-family:Calibri;"
        //    + "	mso-fareast-theme-font:minor-latin;"
        //    + "	mso-hansi-font-family:Calibri;"
        //    + "	mso-hansi-theme-font:minor-latin;"
        //    + "	mso-bidi-font-family:'Times New Roman';"
        //    + "	mso-bidi-theme-font:minor-bidi;}"
        //    + "@list l2:level2"
        //    + "	{mso-level-number-format:alpha-lower;"
        //    + "	mso-level-tab-stop:none;"
        //    + "	mso-level-number-position:left;"
        //    + "	text-indent:-18.0pt;}"
        //    + "@list l2:level3"
        //    + "	{mso-level-number-format:roman-lower;"
        //    + "	mso-level-tab-stop:none;"
        //    + "	mso-level-number-position:right;"
        //    + "	text-indent:-9.0pt;}"
        //    + "@list l2:level4"
        //    + "	{mso-level-tab-stop:none;"
        //    + "	mso-level-number-position:left;"
        //    + "	text-indent:-18.0pt;}"
        //    + "@list l2:level5"
        //    + "	{mso-level-number-format:alpha-lower;"
        //    + "	mso-level-tab-stop:none;"
        //    + "	mso-level-number-position:left;"
        //    + "	text-indent:-18.0pt;}"
        //    + "@list l2:level6"
        //    + "	{mso-level-number-format:roman-lower;"
        //    + "	mso-level-tab-stop:none;"
        //    + "	mso-level-number-position:right;"
        //    + "	text-indent:-9.0pt;}"
        //    + "@list l2:level7"
        //    + "	{mso-level-tab-stop:none;"
        //    + "	mso-level-number-position:left;"
        //    + "	text-indent:-18.0pt;}"
        //    + "@list l2:level8"
        //    + "	{mso-level-number-format:alpha-lower;"
        //    + "	mso-level-tab-stop:none;"
        //    + "	mso-level-number-position:left;"
        //    + "	text-indent:-18.0pt;}"
        //    + "@list l2:level9"
        //    + "	{mso-level-number-format:roman-lower;"
        //    + "	mso-level-tab-stop:none;"
        //    + "	mso-level-number-position:right;"
        //    + "	text-indent:-9.0pt;}"
        //    + "ol"
        //    + "	{margin-bottom:0cm;}"
        //    + "ul"
        //    + "	{margin-bottom:0cm;}"
        //    + "-->";

        //// Aggregate parts of the file together
        //var fileContent = static.mhtml.top.replace("_html_", static.mhtml.head.replace("_styles_", styles) + static.mhtml.body.replace("_body_", '')) + mhtmlBottom;

        //// Create a Blob with the file contents 
        //var blob = new Blob([fileContent], {
        //    type: "application/msword;charset=utf-8"
        //});
        //saveAs(blob, 'PRESTACION_DE_SERVICIOS' + ".pdf");


        //var pdf = new jsPDF('p', 'pt', 'letter');
        //var canvas = pdf.canvas;
        //canvas.height = 72 * 11;
        //canvas.width = 72 * 8.5;
        ///*
        //    console.log(contenido);
        //*/
        //// can also be document.body
        //var html = "<html xmlns:v=3D'urn: schemas-microsoft - com: vml'" +
        //    + "xmlns: o = 3D'urn:schemas-microsoft-com:office:office'"
        //    + "xmlns: w = 3D'urn:schemas-microsoft-com:office:word'"
        //    + "xmlns: m = 3D'http://schemas.microsoft.com/office/2004/12/omml'"
        //    + "xmlns = 3D'http://www.w3.org/TR/REC-html40'><head><meta charset='utf-8'>"
        //    + cuerpoword          
        //    + "</body ></html > ";

        //html2pdf(html, pdf, function (pdf) {
        //    pdf.output('dataurlnewwindow');
        //});


    }
    else {
            alert('agrege los terminos');
    }
}