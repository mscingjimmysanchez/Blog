<%@ Page Language="cs" MasterPageFile="~/Main.Master" AutoEventWireup="True"
    CodeBehind="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="CntContent" runat="server" ContentPlaceHolderID="CphHome">
    <div class="form-horizontal">
        <div class="form-group">
            <asp:Label ID="LblContent" runat="server"></asp:Label>
        </div>
        <div class="form-group">
            <div class="col-md-12">
                <asp:Panel ID="PnlMessage" runat="server" Visible="False">
                    <div class="panel">
                        <asp:Label ID="LblMessage" runat="server" Text="" />
                        <asp:LinkButton ID="LnkClose" runat="server" ForeColor="#A2AAAD" OnClick="LnkClose_Click" CausesValidation="False">Close</asp:LinkButton>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
