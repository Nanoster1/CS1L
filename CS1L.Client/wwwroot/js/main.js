function makeCode(text, container)
{
    new QRCode(document.getElementById(container), text);
}
