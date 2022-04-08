// JScript File
// Janela flutuante

<!--
function MM_showHideLayers() {
  var i,p,v,obj,args=MM_showHideLayers.arguments;
  for (i=0; i<(args.length-2); i+=3) if ((obj=MM_findObj(args[i]))!=null) { v=args[i+2];
    if (obj.style) { obj=obj.style; v=(v=='show')?'visible':(v=='hide')?'hidden':v; }
    obj.visibility=v; }
}
function MM_findObj(n, d) { 
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}

document.write('<div id="fechada" style="position:absolute;widht:100px;height:100px;left:212px;top:252px;visibility:visible;">')

document.write('<table border=0 style="border:1px solid #000000;background-color:#000000;filter:Alpha(Opacity=200,FinishOpacity=95,Style=2,StartX=100,StartY=100,FinishX=100,FinishY=1);"><tr><td>')
document.write('<table width="100" height="125" border="0" cellspacing="1" cellpadding="1">')
document.write('<tr align=right>')
document.write("<td><input type='button' style='background-color:#fefefe;cursor:hand;color:#333333;border:0px;font-face:arial,verdana;font-size:8pt;font-weight:bold;' value=' .::fechar ' onClick=\"MM_showHideLayers('fechada','','hide')\" title='Fechar!'>")
document.write('</td>')
document.write('</tr>')
document.write('<tr>')


document.write('<td><a href="buscar.aspx"><input type=image src=popup.gif style="width:320;height:290;border:0px;" onclick=\'window.open("buscar.aspx","","")\' title="CRP SP informa!"></a></td>')
document.write('</tr>')

document.write('</table>')
document.write('</td>')
document.write('</tr>')
document.write('</table>')
document.write('</div>')
