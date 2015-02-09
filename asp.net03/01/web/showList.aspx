<%@ Page Language="C#" EnableViewState="false" AutoEventWireup="true" CodeBehind="showList.aspx.cs" Inherits="web.showList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
</head>
<body>
     <table>
        <tr>
            <th>用户名</th>
            <th>密码</th>
            <th>操作</th>
        </tr>
        <%foreach (var item in list)
          {%>
          <tr>
            <td><%=item.Uname %></td>
            <td><%=item.Upwd%></td>
            <td><a href="update.aspx?uid=<%=item.Uid %>">更新</a>&nbsp;&nbsp;&nbsp;<a href="?uid=<%=item.Uid  %>">删除</a></td>
          </tr>
        <%} %>
     </table>
     <br />
     <a href="zhuce.aspx">注册</a>
</body>
</html>
