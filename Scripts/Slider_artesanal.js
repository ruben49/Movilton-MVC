$(document).ready(function (e) {  

//cambiar de imagen con los puntitos, y usarlos como botones

//punto 1

$('#btn1').click(function () {

    $('.slider').find('.s_element').each(
     function (index, value) {


         if ($(value).hasClass('s_visible')) {
             $(value).fadeOut("fast");
             $(value).removeClass('s_visible');
             $($('.slider').find('.s_element').get(0)).fadeIn("fast");
             $($('.slider').find('.s_element').get(0)).addClass('s_visible');
 
             return false;

         }

     });




    //cambiar clase del punto

    $('.control_btn').find('.btn_slider').each(
        function (index, value) {


            if ($(value).hasClass('btn_selected')) {
                $(value).removeClass('btn_selected');

                $($('.control_btn').find('.btn_slider').get(0)).addClass('btn_selected');

                return false;

            }


        });





});



//punto 2
$('#btn2').click(function () {

    $('.slider').find('.s_element').each(
     function (index, value) {


         if ($(value).hasClass('s_visible')) {
             $(value).removeClass('s_visible');
             $(value).fadeOut("fast");
             $($('.slider').find('.s_element').get(1)).fadeIn("fast");
             $($('.slider').find('.s_element').get(1)).addClass('s_visible');
             
             


             return false;

         }
     });

    //cambiar clase punto

    $('.control_btn').find('.btn_slider').each(
        function (index, value) {


            if ($(value).hasClass('btn_selected')) {
                $(value).removeClass('btn_selected');

                $($('.control_btn').find('.btn_slider').get(1)).addClass('btn_selected');

                return false;

            }


        });


});



//punto 3
$('#btn3').click(function () {

    $('.slider').find('.s_element').each(
     function (index, value) {



         if ($(value).hasClass('s_visible')) {
             $(value).fadeOut("fast");
             $(value).removeClass('s_visible');
             $($('.slider').find('.s_element').get(2)).fadeIn("fast");
             $($('.slider').find('.s_element').get(2)).addClass('s_visible');
             
             
             return false;

         }



     });

    //cambiar clase al punto

    $('.control_btn').find('.btn_slider').each(
        function (index, value) {


            if ($(value).hasClass('btn_selected')) {
                $(value).removeClass('btn_selected');

                $($('.control_btn').find('.btn_slider').get(2)).addClass('btn_selected');

                return false;

            }


        });

});




//punto 4
$('#btn4').click(function () {

    $('.slider').find('.s_element').each(
     function (index, value) {



         if ($(value).hasClass('s_visible')) {
             $(value).fadeOut("fast");
             $(value).removeClass('s_visible');
             $($('.slider').find('.s_element').get(3)).fadeIn("fast");
             $($('.slider').find('.s_element').get(3)).addClass('s_visible');
             
             
             return false;

         }



     });

    //cambiar clase al punto

    $('.control_btn').find('.btn_slider').each(
        function (index, value) {


            if ($(value).hasClass('btn_selected')) {
                $(value).removeClass('btn_selected');

                $($('.control_btn').find('.btn_slider').get(3)).addClass('btn_selected');

                return false;

            }


        });



});


//punto 5
$('#btn5').click(function () {

    $('.slider').find('.s_element').each(
     function (index, value) {



         if ($(value).hasClass('s_visible')) {
             $(value).fadeOut("fast");
             $(value).removeClass('s_visible');
             $($('.slider').find('.s_element').get(4)).fadeIn("fast");
             $($('.slider').find('.s_element').get(4)).addClass('s_visible');


             return false;

         }



     });

    //cambiar clase al punto

    $('.control_btn').find('.btn_slider').each(
        function (index, value) {


            if ($(value).hasClass('btn_selected')) {
                $(value).removeClass('btn_selected');

                $($('.control_btn').find('.btn_slider').get(4)).addClass('btn_selected');

                return false;

            }


        });



});

//punto 6
$('#btn6').click(function () {
    
    $('.slider').find('.s_element').each(
     function (index, value) {



         if ($(value).hasClass('s_visible')) {
             $(value).fadeOut("fast");
             $(value).removeClass('s_visible');
             $($('.slider').find('.s_element').get(5)).fadeIn("fast");
             $($('.slider').find('.s_element').get(5)).addClass('s_visible');


             return false;

         }



     });

    //cambiar clase al punto

    $('.control_btn').find('.btn_slider').each(
        function (index, value) {


            if ($(value).hasClass('btn_selected')) {
                $(value).removeClass('btn_selected');

                $($('.control_btn').find('.btn_slider').get(5)).addClass('btn_selected');

                return false;

            }


        });



});


//funcion avanzar a la siguiente imagen

function avanzar() {

    var num_items = $('.slider').find('.s_element').size();
    $('.slider').find('.s_element').each(
        function (index, value) {
            if ($(value).hasClass('s_visible')) {
                $(value).fadeOut("fast");
                $(value).removeClass('s_visible');


                if (index + 1  < num_items) {
                    $($('.slider').find('.s_element').get(index + 1)).fadeIn("fast");
                    $($('.slider').find('.s_element').get(index + 1)).addClass('s_visible');
                    return false;

                } else {

                    $($('.slider').find('.s_element').get(0)).fadeIn("fast");
                    $($('.slider').find('.s_element').get(0)).addClass('s_visible');
                    return false;
                }
            }


        });

    //cambiar color punto

    $('.control_btn').find('.btn_slider').each(
        function (index, value) {


            if ($(value).hasClass('btn_selected')) {
                $(value).removeClass('btn_selected');

                if (index + 1 < num_items) {
                    $($('.control_btn').find('.btn_slider').get(index + 1)).addClass('btn_selected');
                    return false;

                } else {
                    $($('.control_btn').find('.btn_slider').get(0)).addClass('btn_selected');
                }
            }


        });


}



//ejecutar funcion avanzar a la siguiente imagen automaticamente

setInterval(avanzar, 5300);

});