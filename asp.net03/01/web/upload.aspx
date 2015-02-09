<%@ Page Language="C#" AutoEventWireup="true" 
 EnableViewState="false" CodeBehind="upload.aspx.cs" Inherits="web.upload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <style></style>
    <script src="script/jquery1.8.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" action="" method="post" enctype="multipart/form-data">
    <input type="button" id="btnadd" value="添加"/>
    <div id="main">
        <div>
        <input type="file" name="file" />
        </div>             
    </div>
    <input type="submit" name="sb" value=" 上传" />
    </form>
</body>
</html>
<script type="text/javascript">
    $(document).ready(function () {

        var main = $("#main");

        var btnadd = $("#btnadd");

        btnadd.click(function () {

            main.append("<div><input type=\"file\" name=\"file\"><input type=\"button\" value=\"删除\"></div>");

            //获取main div里面的最后一个子div
            main.children("div").last().children("input:button").click(function () {
                $(this).parent().remove();
            });
        });

    });
</script>
