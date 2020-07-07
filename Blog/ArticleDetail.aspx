<%@ Page Language="cs" MasterPageFile="~/Main.Master" AutoEventWireup="True"
    CodeBehind="ArticleDetail.aspx.cs" Inherits="ArticleDetail" %>

<asp:Content ID="CntContent" runat="server" ContentPlaceHolderID="CphHome">
    <div class="form-horizontal">
        <div class="form-group">
            <asp:Label ID="LblContent" runat="server"></asp:Label>
            <asp:Label ID="LblComments" runat="server"></asp:Label>
        </div>
        <div class="form-group">
            <label class="col-md-2" for="Name">Name</label>
            <div class="col-md-12">
                <asp:TextBox ID="TxtName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RfvName" runat="server" ErrorMessage="* Name is required" ControlToValidate="TxtName"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <label class="col-md-2" for="Comment">Comment</label>
            <div class="col-md-12">
                <asp:TextBox ID="TxtComment" runat="server" TextMode="MultiLine" Height="200px"
                    Width="100%">
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="RfvComment" runat="server" ErrorMessage="* Comment is required" ControlToValidate="TxtComment"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-6 col-md-6">
                <asp:Button ID="BtnPublish" runat="server" Text="Publish" OnClick="BtnPublish_Click" CssClass="btn btn-default"></asp:Button>
                <asp:Button ID="BtnClean" runat="server" Text="Clean" OnClick="BtnClean_Click" CssClass="btn btn-default" CausesValidation="False" />
            </div>
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
    <div>
        <a href="Home.aspx">Back to Home</a>
    </div>
</asp:Content>
