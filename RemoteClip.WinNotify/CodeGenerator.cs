using QRCoder;
using System;
using System.Drawing;

namespace RemoteClip.Client.Core
{
    public class CodeGenerator
    {
        public Bitmap GetCodeImage(string code)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            return qrCode.GetGraphic(32, Color.Black, Color.FromKnownColor(KnownColor.Transparent), false);
        }

        public byte[] GetCodeBytes(string code)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);

            return qrCode.GetGraphic(32, new byte[] { 0, 0, 0}, new byte[] { 255, 255, 255});
        }
    }
}
