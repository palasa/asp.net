<%@ Page Language="C#" EnableViewState="false" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="web.Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <style type="text/css">
        #dmain
        {
            width:1000px;
            margin:auto auto;    
        }
        #dtop
        {
            width:inherit;
            height:120px;
            border:solid 1px black;
            position:relative;
            margin:0 0 10px 0;
        }
        
        #dleft
        {
            width:150px;
            height:450px;
            border:solid 1px black; 
            float:left;
        }
        #dcontent
        {
            width:830px;
            height:450px;
            border:solid 1px black; 
            float:left;
            margin:0 0 0 15px;    
        }
        .menu
        {
            margin:10px 0 0 10px;
            border:solid 1px black; 
            width:120px;
            height:35px;
            text-align:center;
            
        }
        #dtitle
        {
            width:inherit;
            height:35px;    
        }
    </style>
    <script src="script/jquery1.8.js" type="text/javascript"></script>
</head>
<body>
    <div id="dmain">
        <div id="dtop">
        
        </div>
        <div id="dleft">
            <div class="menu" type="Write.aspx">写信</div>
            <div class="menu" type="InBox.aspx">收件箱</div>
            <div class="menu" type="SendBox.aspx">发件箱</div>
            <div class="menu" type="RubishBox.aspx">垃圾箱</div>
        </div>
        <div id="dcontent">
            <div id="dtitle"></div>
            <iframe id="fr1" frameborder="0"></iframe>
        </div>
    </div>
</body>
</html>
<script type="text/javascript">

    var dtitle = $("#dtitle");

    //菜单的点击事件
    $(".menu").click(function () {

        //$("#fr1").attr("src", $(this).attr("type"));
        dtitle.append("<div>" + $(this).html() + "<span>X</span></div>");
        dtitle.last().addClass("titlecontent");
        dtitle.last().click(function () { 
            

        });

    });

</script>
