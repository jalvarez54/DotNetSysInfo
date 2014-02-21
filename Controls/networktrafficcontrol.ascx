<%@ Control Language="vb" AutoEventWireup="false" Inherits="DotNetSysInfoJA.NetworkTrafficControl" CodeFile="NetworkTrafficControl.ascx.vb" %>
<TABLE class="boxheader" cellSpacing="0" cellPadding="0" width="99%" border="1">
	<TR>
		<TD>
			<TABLE class="boxheader" cellSpacing="0" cellPadding="4" width="100%" border="0">
				<TR vAlign="top">
					<TD class="boxheader" align="center">Traffic Réseau</TD>
				<TR height="1">
					<TD height="1" class="interligne"></TD>
				</TR>
				<TR>
					<TD class="SecondNiveau">Traffic Réseau de la machine</TD>
				</TR>
				<TR>
					<TD class="boxbody">
						<asp:DataGrid id="DataGridTraffic" runat="server" EnableViewState="False" Width="100%" CssClass="boxbody">
							<SelectedItemStyle CssClass="boxbody"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="boxbodyalternate"></AlternatingItemStyle>
							<ItemStyle CssClass="boxbody"></ItemStyle>
							<HeaderStyle CssClass="auteur"></HeaderStyle>
						</asp:DataGrid>
						<asp:Label id="LabelAlert" runat="server" EnableViewState="False" ForeColor="DarkRed" Font-Italic="True"
							Font-Bold="True" Visible="false"></asp:Label>
					</TD>
				</TR>
				<TR height="1">
					<TD height="1" class="interligne"></TD>
				</TR>
				<TR vAlign="top">
					<TD class="boxheader" align="left">&nbsp;</TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</TABLE>
