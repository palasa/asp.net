<%@ Page Language="C#" EnableViewState="false" AutoEventWireup="true" CodeBehind="upload.aspx.cs" Inherits="web.upload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <style type="text/css">
        .u-file-btn {         
            position: relative;
             direction:ltr; 
             height:18px; 
             overflow:hidden;         
             line-height:18px;  
             margin-right:10px; 
             padding:3px;         
             text-align: center;  
             width:105px; 
             background:#880000;
             color:#FFF;

        }
        .u-file-btn input{         
            cursor: pointer; 
            text-align: right; 
            z-index:10; 
            font-size:118px;  
            position: absolute; 
            top:0px; 
            right:0px; 
            opacity:0; 
            filter:Alpha(opacity:0);

        }

    </style>
    <script src="script/jquery1.8.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" action=""  method="post" enctype="multipart/form-data">
    <div class="u-file-c">            
   <input type="file" name="attach"/>选择上传文件
</div>  
    </form>
</body>
</html>
<script type="text/javascript">
    $(document).ready(function () {

        $('.u-file-c').addClass('u-file-btn');
        $('.u-file-c').each(function (i, el) { $(this).html($(this).html()); })

        $("input:file").change(function () {
            $("#form1").submit();
        });
    });

    
</script>
