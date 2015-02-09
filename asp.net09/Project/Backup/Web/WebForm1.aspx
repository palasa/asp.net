<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Web.WebForm1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<title>Insert title here</title>
<script type="text/javascript" src="ck/ckeditor/ckeditor.js" ></script>
<script type="text/javascript">
    window.onload = function () {
        CKEDITOR.replace("t1");
    };
</script>
</head>
<body >
<form action="" method="post">

<textarea cols="30" rows="10" id="t1" name="t1">值应该放在这里</textarea>
<input type="submit" name="sb" value="提交"/>
</form>
</body>
</html>