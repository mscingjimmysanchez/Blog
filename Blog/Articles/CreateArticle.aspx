<%@ Page Language="cs" MasterPageFile="~/Main.Master" AutoEventWireup="True"
    CodeBehind="CreateArticle.aspx.cs" Inherits="CreateArticle" ValidateRequest="false" %>

<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<asp:Content ID="CntContent" runat="server" ContentPlaceHolderID="CphHome">
    <h2>Create
    </h2>
    <div class="form-horizontal">
        <h4>Article</h4>
        <hr />
        <div class="form-group">
            <label class="col-md-2" for="Title">Title</label>
            <div class="col-md-12">
                <asp:TextBox ID="TxtTitle" runat="server" Width="100%"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RfvTitle" runat="server" ErrorMessage="* Title is required" ControlToValidate="TxtTitle"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <label class="col-md-2" for="Contents">Contents</label>
            <div class="col-md-12">
                <ftb:freetextbox id="TxtContents" runat="server" text=""
                    height="200px" width="100%" />
                <asp:RequiredFieldValidator ID="RfvContents" runat="server" ErrorMessage="* Contents are required" ControlToValidate="TxtContents"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <label class="col-md-2" for="Categories">Categories</label>
            <div class="col-md-12">
                <asp:ListBox ID="LbxCategories" runat="server" SelectionMode="Multiple" Width="100%"></asp:ListBox>
                <asp:RequiredFieldValidator ID="RfvCategorias" runat="server" ErrorMessage="* Categories are required" ControlToValidate="LbxCategories"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-6 col-md-6">
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
        <a href="ArticleIndex.aspx">Back to List</a>
    </div>
</asp:Content>
