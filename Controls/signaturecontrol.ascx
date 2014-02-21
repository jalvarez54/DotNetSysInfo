<%@ Control Language="vb" AutoEventWireup="false" Inherits="DotNetSysInfoJA.SignatureControl" CodeFile="SignatureControl.ascx.vb" %>
<TABLE BORDER='1' CELLPADDING='0' CELLSPACING='0' WIDTH='99%' class='boxheader'>
	<TR>
		<TD><TABLE BORDER='0' CELLPADDING='4' CELLSPACING='0' WIDTH='100%' class='boxheader'>
				<TR VALIGN='top'>
					<TD class='boxheader'><asp:Label id="LabelSignature" runat="server" EnableViewState="False"></asp:Label><asp:HyperLink id="HyperLinkSignature" runat="server" EnableViewState="False"></asp:HyperLink><asp:Label id="LabelDate" runat="server" EnableViewState="False"></asp:Label></TD>
					<td class='boxheader' width="200" align="right" valign="top">
						STYLE :
						<asp:DropDownList id="CSSDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList></td>
				</TR>
			</TABLE>
		</TD>
	</TR>
</TABLE>
