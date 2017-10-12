/**
 * @license Copyright (c) 2003-2015, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	
    config.syntaxhighlight_lang = 'csharp';
    config.syntaxhighlight_hideControls = true;
    config.language = 'vi';
    config.filebrowserBrowseUrl = '/Content/libs/ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = '/Content/libs/ckfinder.html?Type=Images';
    config.filebrowserFlashBrowseUrl = '/Content/libs/ckfinder.html?Type=Flash';
    config.filebrowserUploadUrl = '/Content/libs/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = '/Content/UserFiles';
    config.filebrowserFlashUploadUrl = '/Content/libs/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';

    CKFinder.setupCKEditor(null, '/Content/libs/ckfinder/');
};
