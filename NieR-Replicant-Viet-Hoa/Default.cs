using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace NieR_Replicant_Viet_Hoa
{
    public class Default
    {
        public static readonly string _AppDirectory = AppDomain.CurrentDomain.BaseDirectory;
        public static readonly string _LangDirectory = Path.Combine(_AppDirectory, "Languages");
        public static readonly string _FlagFile = Path.Combine(_AppDirectory, "Languages", "flags.bin");
        public static readonly string _ConfigFile = Path.Combine(_AppDirectory, "Config", "config.json");
        public static readonly string _MovieDirectory = @"data\movie";
        public static readonly string _SoundDirectory = @"data\sound";
        public static readonly string _BackupDirectory = "Backup";
        public static readonly string _ExeFile = "NieR Replicant ver.1.22474487139.exe";
        public static readonly string _AppUpdate = Path.Combine(_AppDirectory, "NieR Replicant Update.exe");
        public static string _Uri = "https://lehieugch68.github.io/NieRReplicant/translation.json";
        public static string _Credits = "https://lehieugch68.github.io/NieRReplicant/credits.html";
        public static string _WebUrl = "https://viethoagame.com/threads/pc-nier-replicant-ver-1-22474487139-viet-hoa.305/";
        public static string _Resources = Path.Combine(_AppDirectory, "Resources", "[VietHoaGame.com]_NieR_Replicant_Viet_Hoa.bin");
        public static string _PatchDirectory = "VietHoaGame";
        public static string _MessageTitle = "NieR Replicant Translation";
        public static readonly string[] _DataDirectories = new string[]
        {
            "data", "dlc"
        };
        public static bool _InProgress = false;
        public static Dictionary<string, string> _JsonConfig;
        public static readonly Dictionary<long, string> _ExePointers = new Dictionary<long, string>()
        {
            { 0xABC318, "../build_assets/rom/pc/" },
            { 0xBAD3A0, "../build_assets/rom/pc/snow/%s" },
            { 0xBAD3C0, "../build_assets/rom/pc/snow/script/%s" },
            { 0xBAD3E8, "../build_assets/rom/pc/snow/script/" },
            { 0xBAD410, "../build_assets/rom/pc/" },
        };
        public static readonly string _ExeAssetsPath = "../build_assets/rom/pc/";
        public static Form _CreditForm = new CreditUI();
        public static Dictionary<string, dynamic> _Languages = new Dictionary<string, dynamic>();
        public static Dictionary<string, Image> _Flags = new Dictionary<string, Image>();
        #region Messages
        public static Dictionary<string, string> _Messages = new Dictionary<string, string>()
        {
            { "GameLocation", "NieR Replicant ver.1.22474487139" },
            { "UnsupportedFormat", "Đã xảy ra lỗi: Tệp hỏng hoặc không hỗ trợ.\n\nVui lòng xem lại đường dẫn, tải tệp bị hỏng hoặc cài lại trò chơi." },
            { "NotFound", "Đã xảy ra lỗi: Không tìm thấy tệp.\n\nVui lòng xem lại đường dẫn, tải tệp bị thiếu hoặc cài lại trò chơi." },
            { "InvalidID", "Đã xảy ra lỗi: ID không hợp lệ.\n\nVui lòng cập nhật bản dịch." },
            { "UninstallFailed", "Đã xảy ra lỗi: Gỡ cài đặt thất bại.\n\nCó thể Việt Hóa đã được gỡ cài đặt, hoặc trong quá trình gỡ bị tắt đột ngột, xảy ra sự cố." },
            { "FreeSpace", "Cảnh báo:\n\nĐể cài đặt Việt Hóa, ổ đĩa cần trống khoảng 40GB.\nỔ đĩa của bạn còn trống {TotalFreeSpace}GB. Tiếp tục chứ?" },
            { "BeginInstall", "Bắt đầu cài đặt, vui lòng không tắt chương trình.\nNếu gặp sự cố hoặc tắt chương trình đột ngột, hãy xóa thư mục {PatchDirectory} và cài đặt lại.\nBản dịch được thực hiện bởi Việt Hóa Game và hoàn toàn miễn phí. Vui lòng chỉ tải chương trình ở viethoagame.com để tránh bị chèn mã độc." },
            { "BeginUninstall", "Bắt đầu gỡ cài đặt, vui lòng không tắt chương trình." },
            { "UnpackData", "Đang giải nén {Item}. Tổng: {FileCount} tệp." },
            { "BeginBackup", "Đang sao lưu." },
            { "BeginGetData", "Cập nhập thông tin từ máy chủ." },
            { "CancelInstall", "Đã hủy cài đặt." },
            { "CancelUpdate", "Đã hủy cập nhật." },
            { "CancelUninstall", "Đã hủy gỡ cài đặt." },
            { "DownloadApp", "Đang tải ứng dụng." },
            { "DownloadTrans", "Đang tải bản dịch." },
            { "Extract", "Giải nén {Item}." },
            { "ExtractTrans", "Giải nén bản dịch. Tổng: {FileCount} tệp." },
            { "DownloadCompleted", "Tải thành công." },
            { "InstallCompleted", "Cài đặt thành công." },
            { "UninstallCompleted", "Gỡ Việt Hóa thành công." },
            { "CopyMovieSound", "Đang sao chép Movie và Sound. Tổng: {FileCount} tệp." },
            { "PatchExe", "Đang cập nhật tệp EXE." },
            { "ConfirmUninstall", "Bạn có chắc muốn gỡ cài đặt?" },
            { "BinNotFound", "Đã xảy ra lỗi: Không tìm thấy tệp BIN.\n\nVui lòng cập nhật bản dịch." },
            { "LocationException", "Đã xảy ra lỗi: Không tìm thấy thư mục game.\n\nVui lòng chọn đúng thư mục game." },
            { "InProgress", "Đã xảy ra lỗi: Đang dở tiến trình khác.\n\nVui lòng đợi." },
            { "TranslationID", "ID bản dịch: {ID}" },
            { "AppVersion", "Phiên bản chương trình: {Version}" },
            { "UpdateTime", "Cập nhật ngày: {Date}."},
            { "UpToDate", "Cả chương trình và bản dịch đang ở bản mới nhất." },
            { "ConfirmUpdateApp", "Đã có phiên bản chương trình mới. Bạn muốn cập nhật chứ?" },
            { "ConfirmUpdateTrans", "Đã có bản dịch mới. Bạn muốn cập nhật chứ?" },
            { "Changelog", "\n\nThay đổi:\n" },
        };
        #endregion
    }
}
