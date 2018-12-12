


function toggleBoxTab(prefix, c, bg1, bg2)
	{
	var cells = document.getElementsByTagName('th');

	for(i=0; i<cells.length; i++)
		{
		if(cells[i].id.indexOf(prefix) == 0)
			{
			if(cells[i].id == prefix+c)
				{
				cells[i].style.backgroundColor=bg1
				}
			else
				{
				cells[i].style.backgroundColor=bg2
				}
			}
		}
	}

function showBoxDiv(prefix, vid)
	{
	// vid gets displayed, anything beginning with prefix gets hidden

	var divs = document.getElementsByTagName('div');

	for(i=0; i<divs.length; i++)
		{
		if(divs[i].id.indexOf(prefix) == 0)
			{
			if(divs[i].id == vid)
				{
				if (document.getElementById) // DOM3 = IE5, NS6
					{
					divs[i].style.display = 'block';
					divs[i].style.visibility = 'visible';
					divs[i].style.height = '';
					}
				else if (document.layers) // Netscape 4
					{
					document.layers[divs[i]].display = 'visible';
					}
				else // IE 4
					{
					document.all.divs[i].visibility = 'visible';
					}
				}
			else if (document.getElementById)
				{
				divs[i].style.display = 'none';
				divs[i].style.visibility = 'hidden';
				divs[i].style.height = '0px';
				}
			else if (document.layers)
				{
				document.divs[i].visibility = 'hidden';
				}
			else // IE 4
				{
				document.all.divs[i].visibility = 'hidden';
				}
			}
		}
	}

function disableSelect(prefix, vid)
	{
	// vid gets enabled, anything beginning with prefix gets disabled

	var selects = document.getElementsByTagName('select');

	for(i=0; i<selects.length; i++)
		{
		if(selects[i].id.indexOf(prefix) == 0)
			{
			if(selects[i].id == vid)
				{
				selects[i].disabled = false;
				}
			else
				{
				selects[i].disabled = true;
				}
			}
		}
	}

function disableDivInputs(prefix, vid)
	{
	// all inputs within div=vid get enabled, anything within div beginning with prefix gets disabled

	var divs = document.getElementsByTagName('div');

	for(i=0; i<divs.length; i++)
		{
		if(divs[i].id.indexOf(prefix) == 0)
			{
			var inputs = divs[i].getElementsByTagName('input');

			for(j=0; j<inputs.length; j++)
				{
				if(divs[i].id == vid)
					{
					inputs[j].disabled = false;
					}
				else
					{
					inputs[j].disabled = true;
					}
				}
			}
		}
	}

/***********************************************
* IFrame SSI script II- © Dynamic Drive DHTML code library (http://www.dynamicdrive.com)
* Visit DynamicDrive.com for hundreds of original DHTML scripts
* This notice must stay intact for legal use
***********************************************/

//Input the IDs of the IFRAMES you wish to dynamically resize to match its content height:
//Separate each ID with a comma. Examples: ["myframe1", "myframe2"] or ["myframe"] or [] for none:
//var iframeids=["comments", "livescoresbox"]
var iframeids=["comments"]

//Should script hide iframe from browsers that don't support this script (non IE5+/NS6+ browsers. Recommended):
var iframehide="yes"

var getFFVersion  = navigator.userAgent.substring(navigator.userAgent.indexOf("Firefox")).split("/")[1]

var FFextraHeight = (parseFloat(getFFVersion) >= 1.0 && parseFloat(getFFVersion) <= 1.9) ? 16 : 4 //extra height in px to add to iframe in FireFox 1.0+ browsers

function resizeCaller()
	{
	var dyniframe=new Array()
	for (i=0; i<iframeids.length; i++)
		{
		if (document.getElementById)
			resizeIframe(iframeids[i])

		//reveal iframe for lower end browsers? (see var above):
		if ((document.all || document.getElementById) && iframehide == "no")
			{
			var tempobj = document.all ? document.all[iframeids[i]] : document.getElementById(iframeids[i])
			tempobj.style.display="block"
			}
		}
	}

function resizeIframe(frameid)
	{
	var currentfr=document.getElementById(frameid)
	if (currentfr && !window.opera)
		{
		currentfr.style.display="block"
		if (currentfr.contentDocument && currentfr.contentDocument.body.offsetHeight) //ns6 syntax
			currentfr.height = currentfr.contentDocument.body.offsetHeight+FFextraHeight; 
		else if (currentfr.Document && currentfr.Document.body.scrollHeight) //ie5+ syntax
			currentfr.height = currentfr.Document.body.scrollHeight;
		if (currentfr.addEventListener)
			currentfr.addEventListener("load", readjustIframe, false)
		else if (currentfr.attachEvent)
			{
			currentfr.detachEvent("onload", readjustIframe) // Bug fix line
			currentfr.attachEvent("onload", readjustIframe)
			}
		}
	}

function readjustIframe(loadevt)
	{
	var crossevt=(window.event)? event : loadevt
	var iframeroot=(crossevt.currentTarget)? crossevt.currentTarget : crossevt.srcElement
	if (iframeroot)
		resizeIframe(iframeroot.id);
	}

function loadintoIframe(iframeid, url)
	{
	if (document.getElementById)
		document.getElementById(iframeid).src=url
	}


if (window.addEventListener)
	window.addEventListener("load", resizeCaller, false)
else if (window.attachEvent)
	window.attachEvent("onload", resizeCaller)
else
	window.onload=resizeCaller


