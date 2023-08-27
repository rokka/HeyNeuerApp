namespace HeyNeuer.Models.ApiModels;

public class GetComputerResponse
{
    public Computer computer { get; set; }
}

public class Computer
{
    public int id { get; set; }
    public int team_id { get; set; }
    public object position_id { get; set; }
    public int number { get; set; }
    public string donor { get; set; }
    public object email { get; set; }
    public int type { get; set; }
    public string model { get; set; }
    public int memory_in_gb { get; set; }
    public int hard_drive_type { get; set; }
    public int hard_drive_space_in_gb { get; set; }
    public int has_vga_videoport { get; set; }
    public int has_dvi_videoport { get; set; }
    public int has_hdmi_videoport { get; set; }
    public int has_displayport_videoport { get; set; }
    public string cpu { get; set; }
    public int has_webcam { get; set; }
    public int has_wlan { get; set; }
    public string required_equipment { get; set; }
    public int is_deletion_required { get; set; }
    public int needs_donation_receipt { get; set; }
    public string state { get; set; }
    public string comment { get; set; }
    public DateTime? created_at { get; set; }
    public DateTime? updated_at { get; set; }
}