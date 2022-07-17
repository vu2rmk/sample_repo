sample_repo
===========

This is a sample repo.


<script>
        $(document).ready(function(){
            $("#test").click(function () {

                fetch("/Home/DownloadFileZip", {
                    method: 'POST',
                    data: { filename: 'data.pdf' }
                })
                .then(response => response.blob())
                .then(blob => {
                    var url = window.URL.createObjectURL(blob);
                    var a = document.createElement('a');
                    a.href = url;
                    a.download = "filename.zip";
                    document.body.appendChild(a); // we need to append the element to the dom -> otherwise it will not work in firefox
                    a.click();
                    a.remove();
                });
              //$.ajax({
              //    type: "POST",
              //    url: "/Home/DownloadFileClean",
              //    data: '{fileName: "data.pdf"}',
              //    contentType: "application/json; charset=utf-8",
              //    dataType: "text",
              //    success: function (r) {
              //        var fileName = "sum.zip";
              //        //Convert Base64 string to Byte Array.
              //        var bytes = Base64ToBytes(r);

              //        //Convert Byte Array to BLOB.
              //        var blob = new Blob([bytes], { type: "application/octetstream" });

              //        //Check the Browser type and download the File.
              //        var isIE = false || !!document.documentMode;
              //        if (isIE) {
              //            window.navigator.msSaveBlob(blob, fileName);
              //        } else {
              //            var url = window.URL || window.webkitURL;
              //            link = url.createObjectURL(blob);
              //            var a = $("<a />");
              //            a.attr("download", fileName);
              //            a.attr("href", link);
              //            $("body").append(a);
              //            a[0].click();
              //            $("body").remove(a);
              //        }
              //    }
              //});
          });
          function Base64ToBytes(base64) {
              var s = window.atob(base64);
              var bytes = new Uint8Array(s.length);
              for (var i = 0; i < s.length; i++) {
                  bytes[i] = s.charCodeAt(i);
              }
              return bytes;
          };
        });
    </script>
