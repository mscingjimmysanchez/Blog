<%@ Page Language="cs" MasterPageFile="~/Main.Master" AutoEventWireup="True"
    CodeBehind="CreateCategory.aspx.cs" Inherits="CreateCategory" %>

<asp:Content ID="CntContent" runat="server" ContentPlaceHolderID="CphHome">
    <h2>Create
    </h2>
    <div class="form-horizontal">
        <h4>Category</h4>
        <hr />
        <div class="form-group">
            <label class="col-md-2" for="Name">Name</label>
            <div class="col-md-12">
                <asp:TextBox ID="TxtName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RfvName" runat="server" ErrorMessage="* Name is required" ControlToValidate="TxtName"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-0 col-md-12">
                <asp:Button ID="BtnCreate" runat="server" Text="Create" OnClick="BtnCreate_Click" CssClass="btn btn-default"></asp:Button>
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
        <a href="CategoryIndex.aspx">Back to List</a>
    </div>
</asp:Content>
