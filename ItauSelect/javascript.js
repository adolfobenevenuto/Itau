function validateLimit(obj, divID, maxchar) {
    objDiv = get_object(divID);
    if (this.id) obj = this;
    var remaningChar = maxchar - obj.value.length;
    if (objDiv) {
        objDiv.innerHTML = remaningChar + " characters left";
    }
    if (remaningChar <= 0) {
        obj.value = obj.value.substring(maxchar, 0);
        if (objDiv) {
            objDiv.innerHTML = "0 characters left";
        }
        return false;
    }
    else
    { return true; }
}

function get_object(id) {
    var object = null;
    if (document.layers) {
        object = document.layers[id];
    } else if (document.all) {
        object = document.all[id];
    } else if (document.getElementById) {
        object = document.getElementById(id);
    }
    return object;
}

 function txtBoxFormat(objeto, sMask, evtKeyPress) {
			var i, nCount, sValue, fldLen, mskLen,bolMask, sCod, nTecla;

			if(document.all) { // Internet Explorer
				nTecla = evtKeyPress.keyCode; }
			else if(document.layers) { // Nestcape
				nTecla = evtKeyPress.which;
			}

			sValue = objeto.value;

			// Limpa todos os caracteres de formatação que
			// já estiverem no campo.
			sValue = sValue.toString().replace( "-", "" );
			sValue = sValue.toString().replace( "-", "" );
			sValue = sValue.toString().replace( ".", "" );
			sValue = sValue.toString().replace( ".", "" );
			sValue = sValue.toString().replace( "/", "" );
			sValue = sValue.toString().replace( "/", "" );
			sValue = sValue.toString().replace( ":", "" );
			sValue = sValue.toString().replace( ":", "" );
			sValue = sValue.toString().replace( "(", "" );
			sValue = sValue.toString().replace( "(", "" );
			sValue = sValue.toString().replace( ")", "" );
			sValue = sValue.toString().replace( ")", "" );
			sValue = sValue.toString().replace( " ", "" );
			sValue = sValue.toString().replace( " ", "" );
			fldLen = sValue.length;
			mskLen = sMask.length;

			i = 0;
			nCount = 0;
			sCod = "";
			mskLen = fldLen;

			while (i <= mskLen) {
				bolMask = ((sMask.charAt(i) == "-") || (sMask.charAt(i) == ".") ||
(sMask.charAt(i) == "/") || (sMask.charAt(i) == ":"))
				bolMask = bolMask || ((sMask.charAt(i) == "(") || (sMask.charAt(i) ==
")") || (sMask.charAt(i) == " "))

		   if (bolMask) {
		        sCod += sMask.charAt(i);
				mskLen++; }
			else {
				sCod += sValue.charAt(nCount);
				nCount++;
			}

				i++;
			}

			objeto.value = sCod;

			if (nTecla != 8) { // backspace
				if (sMask.charAt(i-1) == "9") { // apenas números...
					return ((nTecla > 47) && (nTecla < 58)); } // números de 0 a 9
				else { // qualquer caracter...
					return true;
				}
			}
			else {
				return true;
			}
		}



// mascara dos campos
function Mascara(objeto){
   if(objeto.value.length == 0)
     objeto.value = '(' + objeto.value;

   if(objeto.value.length == 3)
      objeto.value = objeto.value + ')';

 if(objeto.value.length == 8)
     objeto.value = objeto.value + '-';
}

function MM_formtCep(e,src,mask) {  
  if(window.event) { _TXT = e.keyCode; }     
  else if(e.which) { _TXT = e.which; }    
  if(_TXT > 47 && _TXT < 58) {  var i = src.value.length; var saida = mask.substring(0,1); var texto = mask.substring(i) 
  if (texto.substring(0,1) != saida) { src.value += texto.substring(0,1); }     return true; } 
  else 
  { 
  if (_TXT != 8) { return false; }  
  else { 
  return true; }    }}
