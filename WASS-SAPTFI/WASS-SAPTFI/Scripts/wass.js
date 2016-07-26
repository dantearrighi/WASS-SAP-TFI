

$(function () {

    var ajaxFormSubmit = function () {
        var $form = $(this);

        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };

        $.ajax(options).done(function (data) {
            var $target = $($form.attr("data-wass-target"));
            var $newHtml = $(data);
            $target.replaceWith($newHtml);
            $newHtml.effect("highlight");
        });

        return false;
    };

    var createAutocomplete = function () {
        var $input = $(this);

        var options = {
            source: $input.attr("data-wass-autocomplete")

        };

        $input.autocomplete(options);
    };


    $("form[data-wass-ajax='true']").submit(ajaxFormSubmit);
    $("input[data-wass-autocomplete]").each(createAutocomplete);
});