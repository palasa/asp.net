<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="web.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
</head>
<body>
    <form id="form1" action="#" method="post">
        <input type="text" name="uname" /><br />
        <input type="password" name="upwd" /><br />
        <input type="submit" name="sub" value="登录"/>
    </form>

    <br />
    <%=message%>
</body>
</html>
