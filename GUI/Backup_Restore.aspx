<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Backup_Restore.aspx.vb" Inherits="GUI.Backup_Restore" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
    function checkFileExtension(elem) {
        var filePath = elem.value;

        if (filePath.indexOf('.') == -1)
            return false;

        var validExtensions = new Array();
        var ext = filePath.substring(filePath.lastIndexOf('.') + 1).toLowerCase();

        validExtensions[0] = 'bak';
        //validExtensions[1] = 'jpeg';
        //validExtensions[2] = 'bmp';
        //validExtensions[3] = 'png';
        //validExtensions[4] = 'gif';
        //validExtensions[5] = 'tif';
        //validExtensions[6] = 'tiff';
        //validExtensions[7] = 'txt';
        //validExtensions[8] = 'doc';
        //validExtensions[9] = 'xls';
        //validExtensions[10] = 'pdf';

        for (var i = 0; i < validExtensions.length; i++) {
            if (ext == validExtensions[i])
                return true;
        }

        elem.value = "";
        alert('La extensión ' + ext.toUpperCase() + ' no está permitida!');
        return false;
    }
</script>


    <section id="portfolio" class="section-bg">
        <div class="container">
            <br />
            <br />
            <br />
            <h3>Backup / Restore</h3>

                  
            <div class="form-group">
                <div class="container">
                    <div class="card-body">
                        <div class="card card-body">
                            <div class="mr-0">
                                <div style="text-align: center">
                                    <h3>Backup</h3>
                                    <small>Gestionar un nuevo BackUp del estado actual de la Base de Datos</small>
                                </div>
                                <br />
                                <div style="text-align: center">
                                    <asp:Button ID="btn_RealizarBackUp" runat="server" CssClass="btn btn-primary" Text="Realizar BackUp" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="container">
                    <div class="card-body">
                        <div class="card card-body">
                            <div class="mr-0">
                                <div style="text-align: center">
                                    <h3>Restore</h3>
                                    <small>Seleccione el Backup que necesita Restaurar</small>

                                    <br />

                                    <asp:FileUpload ID="FileUpload1" runat="server" />

                                    <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Cargar" OnClientClick="return confirm('Está seguro de realizar la acción?');" />

                                </div>
                            </div>
                        </div>
                    </div>

                </div>

            </div>
        </div>
    </section>
</asp:Content>
