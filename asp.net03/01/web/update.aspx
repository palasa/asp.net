<%@ Page Language="C#" AutoEventWireup="true"  EnableViewState="false" CodeBehind="update.aspx.cs" Inherits="web.update" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head >
    <title></title>
</head>
<body>
    <form id="form1" action="#" method="post">
    <input type="text" name="uname" value="<%=datamodel.Tables[0].Rows[0]["uname"] %>" /><br />
    <input type="password" name="upwd" value="<%=datamodel.Tables[0].Rows[0]["upwd"] %>"/><br />
    <input type="hidden" value="<%=datamodel.Tables[0].Rows[0]["uid"] %>" name="uid" />
    <input type="submit" name="sub" value="更新"/><br />
    </form>
    <br />
    <br />
    <%=message%>
</body>
</html>
