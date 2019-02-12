﻿(function() {
    $(function() {

        var _service = abp.services.app.reference;
		var _$modal = $('#CreateOrEditModal');
		var _$form = _$modal.find('form');
		var type = $('#Type').val();

        _$form.validate();

        $('#RefreshButton').click(function () {
            reloadPage();
        });

        $('.delete-item').click(function () {
            var id = $(this).attr("data-item-id");
            var name = $(this).attr('data-item-name');

			abp.message.confirm(
				abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'InstaPoisk'), name),
				function (isConfirmed) {
					if (isConfirmed) {
						_service.delete(id, type).done(function () {
							reloadPage();
						});
					}
				}
			);
        });

        $('.edit-item').click(function (e) {
            var id = $(this).attr("data-item-id");

            e.preventDefault();
            $.ajax({
				url: abp.appPath + 'Admin/Reference/CreateOrEditCategory?type=' + type + '&id=' + id,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
					$('#CreateOrEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
		});

        $('.create-item').click(function (e) {
	        e.preventDefault();
	        $.ajax({
				url: abp.appPath + 'Admin/Reference/CreateOrEditCategory?type=' + type,
		        type: 'POST',
		        contentType: 'application/html',
		        success: function (content) {
			        $('#CreateOrEditModal div.modal-content').html(content);
		        },
		        error: function (e) { }
	        });
        });

        
        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

		function reloadPage() {
            location.reload(true); //reload page to see new user!
        }
    });
})();