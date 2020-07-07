<%@ Page Language="cs" MasterPageFile="~/Main.Master" AutoEventWireup="True" CodeBehind="DeleteComment.aspx.cs" Inherits="DeleteComment" %>

<asp:Content ID="CntContent" runat="server" ContentPlaceHolderID="CphHome">
    <h2>Delete
    </h2>
    <div class="form-horizontal">
        <h4>Comment</h4>
        <hr />
        <div class="form-group">
            <label class="col-md-2" for="Article">Article</label>
            <div class="col-md-12">
                <asp:Label ID="LblArticle" runat="server"></asp:Label>
            </div>
        </div>
        <div class="form-group">
            <label class="col-md-2" for="Name">Name</label>
            <div class="col-md-12">
                <asp:Label ID="LblName" runat="server"></asp:Label>
            </div>
        </div>
        <div class="form-group">
            <label class="col-md-2" for="Contents">Contents</label>
            <div class="col-md-12">
                <asp:Label ID="LblContents" runat="server"></asp:Label>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-0 col-md-12">
                <asp:Button ID="BtnDelete" runat="server" Text="Delete" OnClick="BtnDelete_Click" CssClass="btn btn-default"></asp:Button>
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
        <a href="CommentIndex.aspx">Back to List</a>
    </div>
</asp:Content>
