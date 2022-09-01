
var page                = new Page("/InformationManagement/DocumentRequests");
var employeeId          = null;

var commentAttachments  = [];
var supportingFiles     = [];
var externalDocuments   = [];
$(function () {

    $('.fld-editor').trumbowyg({
        plugins: {
            resizimg: {
                minSize: 64,
                step: 16,
            }
        },
        semantic: false,
        btnsDef: {
            alignments: {
                dropdown: ['justifyLeft', 'justifyCenter', 'justifyRight', 'justifyFull'],
                ico: 'justifyCenter'
            }
        },
        btns: [['undo', 'redo'], // Only supported in Blink browsers
            ['table'],
            ['fontfamily', 'fontsize'],
            ['bold', 'italic', 'strikethrough', 'foreColor', 'backColor', 'alignments'],
            ['indent', 'outdent'],
            ['superscript', 'subscript'],
            ['unorderedList', 'orderedList'],
            ['horizontalRule'],
            ['removeformat'],
            ['fullscreen']]
    });

    $(document).on('click', '#btn-hide-info', function () {
        $('#document-info').addClass('d-none');
        $('#btn-show-info').removeClass('d-none');
        $('#btn-hide-info').addClass('d-none');
    });

    $(document).on('click', '#btn-show-info', function () {
        $('#document-info').removeClass('d-none');
        $('#btn-hide-info').removeClass('d-none');
        $('#btn-show-info').addClass('d-none');
    });

    $(document).on('click', '#btn-upload', function () {
        $('#mdl-file-upload').modal('show');
    });

    $(document).on('click', '#btn-upload-external', function () {
        $('#mdl-file-upload-external').modal('show');
    });

    $(document).on('change', '#file-file-upload-external', function () {

        $.ajax({
            url: '/humancapital/employees/UploadDocument',
            type: 'POST',
            data: new FormData($('#frm-fle-uploader-external')[0]),
            cache: false,
            contentType: false,
            processData: false,
            success: function (file) {
                $('#file-file-upload-external').val('');
                $("#file-uploadfile-progress-external").attr({
                    value: 0,
                    max: 100
                });
                $('#mdl-file-upload-external').modal('hide');
                notify('File uploaded', 'success');
                $('#fld-file-name-external').val(file.Item3);
                $('#fld-original-file-name-external').val(file.Item1);
                $('.lbl-file-external').append('<a target="_blank" href="/content/files/' + file.Item3 + '">' + file.Item1 + '</a><br />');

                var id = $('#fld-document-request-id').val();
                externalDocuments.push({
                    'DocumentRequestId': id,
                    'ExternalDocumentOriginalFileName': file.Item1,
                    'ExternalDocumentUniqueFileName': file.Item3
                });
            },
            error: function (b) {
                console.log(b);
            },
            xhr: function () {
                var fileXhr = $.ajaxSettings.xhr();
                if (fileXhr.upload) {
                    $("#file-uploadfile-progress-external").show();
                    fileXhr.upload.addEventListener("progress", function (e) {
                        if (e.lengthComputable) {
                            $("#file-uploadfile-progress-external").attr({
                                value: e.loaded,
                                max: e.total
                            });
                            $("#file-uploadfile-progress-external").hide();
                        }
                    }, false);
                }
                return fileXhr;
            }
        });

    });

    $(document).on('change', '#file-file-upload', function () {

        $.ajax({
            url: '/humancapital/employees/UploadDocument',
            type: 'POST',
            data: new FormData($('#frm-fle-uploader')[0]),
            cache: false,
            contentType: false,
            processData: false,
            success: function (file) {
                $('#file-file-upload').val('');
                $("#file-uploadfile-progress").attr({
                    value: 0,
                    max: 100
                });
                $('#mdl-file-upload').modal('hide');
                notify('File uploaded', 'success');
                $('#fld-file-name').val(file.Item3);
                $('#fld-original-file-name').val(file.Item1);
                $('.lbl-file').append('<a target="_blank" href="/content/files/' + file.Item3 + '">' + file.Item1 + '</a><br />');

                var id = $('#fld-document-request-id').val();
                supportingFiles.push({
                    'DocumentRequestId': id,
                    'OriginalFileName' : file.Item1,
                    'UniqueFileName'   : file.Item3
                });
            },
            error: function (b) {
                console.log(b);
            },
            xhr: function () {
                var fileXhr = $.ajaxSettings.xhr();
                if (fileXhr.upload) {
                    $("#file-uploadfile-progress").show();
                    fileXhr.upload.addEventListener("progress", function (e) {
                        if (e.lengthComputable) {
                            $("#file-uploadfile-progress").attr({
                                value: e.loaded,
                                max: e.total
                            });
                        }
                    }, false);
                }
                return fileXhr;
            }
        });

    });

    $(document).on('click', '#btn-attachment-file', function () {
        $('#mdl-file-attachment').modal('show');
    });

    $(document).on('change', '#fle-attachment-file-upload', function () {

        $.ajax({
            url: '/humancapital/employees/UploadDocument',
            type: 'POST',
            data: new FormData($('#frm-attachment-file-uploader')[0]),
            cache: false,
            contentType: false,
            processData: false,
            success: function (file) {
                $('#fle-attachment-file-upload').val('');
                $("#file-attachment-upload-progress").attr({
                    value: 0,
                    max: 100
                });
                $('#mdl-file-attachment').modal('hide');
                notify('File uploaded', 'success');
                $('#fld-attachment-file-name').val(file.Item3);
                $('#fld-attachment-original-file-name').val(file.Item1);
                $('.lbl-attachment-file').append('<a target="_blank" href="/content/files/' + file.Item3 + '">' + file.Item1 + '</a><br />');
                var id = $('#fld-document-request-id').val();

                commentAttachments.push({
                    'DocumentRequestId': id,
                    'UniqueFileName': file.Item3,
                    'OrginalFileName': file.Item1
                });


            },
            error: function (b) {
                console.log(b);
            },
            xhr: function () {
                var fileXhr = $.ajaxSettings.xhr();
                if (fileXhr.upload) {
                    $("#file-attachment-upload-progress").show();
                    fileXhr.upload.addEventListener("progress", function (e) {
                        if (e.lengthComputable) {
                            $("#file-attachment-upload-progress").attr({
                                value: e.loaded,
                                max: e.total
                            });
                        }
                    }, false);
                }
                return fileXhr;
            }
        });

    });

    $(document).on('click', '#btn-back', function () {
        history.go(-1);
    });

    $(document).on('click', '#btn-send-comment', function () {

        var validation = page.validate('.new-comment', 'DocumentRequestComment');

        if (validation.Valid) {
            validation.Entity['DocumentRequestComment.Attachments'] = commentAttachments;
            page.save(validation.Entity, '/SaveComment', $('#btn-send-comment'), 'Comment Added', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />') + validateAttachment.Message.join('<br />'), 'error')
        }

    });

    $(document).on('click', '#btn-update-draft', function () {
        var validation = page.validate('.dv-content', 'DocumentRequest');

        if (validation.Valid) {
            if (supportingFiles.length != 0) {
                validation.Entity['DocumentRequest.SupportingDocuments'] = supportingFiles;
            }
            if (externalDocuments.length != 0) {
                validation.Entity['DocumentRequest.DocumentRequestExternalDocuments'] = externalDocuments;
            }

            page.save(validation.Entity, '/UpdateContent', $('#btn-update-draft'), 'Draft Updated', 'Save failed', done);
        } else {
            notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
        }

    });


    $(document).on('click', '#btn-submit', function () {

        var content         = $('#hdn-document-content').val();
        var fileUploaded    = $('#fld-upload-file-content-name').val();
        var textEditorVal   = $('.fld-editor').val();

        if (content != '' || fileUploaded != '' || textEditorVal != '') {
            var validation = page.validate('.dv-content', 'DocumentRequest');

            if (validation.Valid) {
                if (supportingFiles.length != 0) {
                    validation.Entity['DocumentRequest.SupportingDocuments'] = supportingFiles;
                }
                if (externalDocuments.length != 0) {
                    validation.Entity['DocumentRequest.DocumentRequestExternalDocuments'] = externalDocuments;
                }

                page.save(validation.Entity, '/UpdateContent', $('#btn-submit'), 'Document Request Submitted', 'Save failed', submit);

            } else {
                notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
            }

        } else {
            notify('No document found. <br />Please check your document. ', 'error')
        }




    });

    $(document).on('click', '#btn-approve-document-request', function () {

        var authorityId = $(this).data('id');
        var id = $('#fld-document-request-id').val();
        employeeId = $('#fld-current-employee-id').val();
        showConfirm("Are you sure you want to approve this document?", approveDocument, id);
    });

    $(document).on('click', '#btn-edit-document-request', function () {
        $('#dv-pdf-viewer').addClass('d-none');
        $('#dv-content-highlighter').removeClass('d-none');

        $('#btn-edit-document-request').addClass('d-none');
        $('#btn-view-document-pdf').removeClass('d-none');
    });

    $(document).on('click', '#btn-view-document-pdf', function () {

        done();

    });

    $(document).on('mousedown', '#dv-content-highlighter', function () {

        $(document).on('mouseup', '#dv-content-highlighter', function () {
            var text = "";
            if (window.getSelection) {
                text = window.getSelection().toString();
            } else if (document.selection && document.selection.type != "Control") {
                text = document.selection.createRange().text;
            }
            if (text.trim() != '') {
                Popper.createPopper(button, tooltip, {
                    placement: 'right',
                });
            }

        });

    });

    $(document).on('click', '.btn-command', function () {



    });

    $(document).on('click', '#btn-edit-document-listen', function () {

        var toSpeak = $('#dv-content-highlighter').text();
        var speech = new SpeechSynthesisUtterance();
        speech.text = toSpeak.replace(/\r?\n|\r/g, ' ');
        window.speechSynthesis.speak(speech);

    });

    displayPDF();

    $(document).on('click', '#btn-upload-content', function () {
        $('#mdl-upload-file-content').modal('show');
    });

    $(document).on('change', '#upload-file-content-upload', function () {

        $.ajax({
            url: '/humancapital/employees/UploadDocument',
            type: 'POST',
            data: new FormData($('#frm-upload-file-content-uploader')[0]),
            cache: false,
            contentType: false,
            processData: false,
            success: function (file) {
                $('#upload-file-content-upload').val('');
                $("#upload-file-content-progress").attr({
                    value: 0,
                    max: 100
                });
                $('#mdl-upload-file-content').modal('hide');
                notify('File uploaded', 'success');
                $('#fld-upload-file-content-name').val(file.Item3);
                $('#fld-upload-file-content-original-file-name').val(file.Item1);

                var uploadedContentOriginalFileName = file.Item1;
                var uploadedContentUniqueFileName = file.Item3;

                var validation = page.validate('.dv-content', 'DocumentRequest');

                if (validation.Valid) {

                    validation.Entity['DocumentRequest.UniqueFileName']     = uploadedContentUniqueFileName;
                    validation.Entity['DocumentRequest.OriginalFileName']   = uploadedContentOriginalFileName;
                    page.saveDirect(validation.Entity, '/UploadContentFile', done);
                } else {
                    notify('<strong>Complete all the required fields:</strong><br /><br />' + validation.Message.join('<br />'), 'error')
                }

            },
            error: function (b) {
                console.log(b);
            },
            xhr: function () {
                var fileXhr = $.ajaxSettings.xhr();
                if (fileXhr.upload) {
                    $("#upload-file-content-progress").show();
                    fileXhr.upload.addEventListener("progress", function (e) {
                        if (e.lengthComputable) {
                            $("#upload-file-content-progress").attr({
                                value: e.loaded,
                                max: e.total
                            });
                            $("#upload-file-content-progress").hide();
                        }
                    }, false);
                }
                return fileXhr;
            }
        });

    });

});

var submit = function () {
    var id = $('#fld-document-request-id').val();

    page.get('/Submit?id=' + id).then(function () {
        done();
    });
}

var approveDocument = function (id) {
    page.get('/Approve?id=' + id + '&employeeId=' + employeeId).then(function (data) {
        done();
    });
}

var done = function () {
    setTimeout(
        function () {
            location.reload();
        }, 1000);
}

var displayPDF = function () {
    var id = $('#hdn-document-request-id').val().substring(0, 5);;
    var name = $('#hdn-document-request-name').val();
    PDFObject.embed("../../../content/files/" + name + '-' + id + '.pdf', "#dv-pdf-viewer");
}

function getSelectedNode() {
    if (document.selection) {
        return document.selection.createRange().parentElement();
    } else {
        var selection = window.getSelection();
        if (selection.rangeCount > 0)
            return selection.getRangeAt(0).startContainer.parentNode;
    }
}

