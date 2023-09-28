using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace kion
{
    public partial class Default : System.Web.UI.Page
    {
        kionEntities1 db = new kionEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var uniDoldur = db.universite.ToList();
            }



        }

        public static bool TcDogrulaV2(string tcKimlikNo)
        {
            bool returnvalue = false;
            if (tcKimlikNo.Length == 11)
            {
                Int64 ATCNO, BTCNO, TcNo;
                long C1, C2, C3, C4, C5, C6, C7, C8, C9, Q1, Q2;

                TcNo = Int64.Parse(tcKimlikNo);

                ATCNO = TcNo / 100;
                BTCNO = TcNo / 100;

                C1 = ATCNO % 10; ATCNO = ATCNO / 10;
                C2 = ATCNO % 10; ATCNO = ATCNO / 10;
                C3 = ATCNO % 10; ATCNO = ATCNO / 10;
                C4 = ATCNO % 10; ATCNO = ATCNO / 10;
                C5 = ATCNO % 10; ATCNO = ATCNO / 10;
                C6 = ATCNO % 10; ATCNO = ATCNO / 10;
                C7 = ATCNO % 10; ATCNO = ATCNO / 10;
                C8 = ATCNO % 10; ATCNO = ATCNO / 10;
                C9 = ATCNO % 10; ATCNO = ATCNO / 10;
                Q1 = ((10 - ((((C1 + C3 + C5 + C7 + C9) * 3) + (C2 + C4 + C6 + C8)) % 10)) % 10);
                Q2 = ((10 - (((((C2 + C4 + C6 + C8) + Q1) * 3) + (C1 + C3 + C5 + C7 + C9)) % 10)) % 10);

                returnvalue = ((BTCNO * 100) + (Q1 * 10) + Q2 == TcNo);
            }
            return returnvalue;
        }

        protected void txtTckn_TextChanged(object sender, EventArgs e)
        {
            if (txtTckn.Text.Length == 11)
            {
                bool dogrula = TcDogrulaV2(txtTckn.Text);
                if (dogrula == true)
                {
                    txtTckn.BorderColor = System.Drawing.Color.LightGreen;
                    txtTckn.BorderWidth = 2;
                }
                else
                {
                    txtTckn.BorderColor = System.Drawing.Color.Red;
                    txtTckn.BorderWidth = 2;
                }
            }
            else
            {
                txtTckn.BorderColor = System.Drawing.Color.Red;
                txtTckn.BorderWidth = 2;
            }
        }

        protected void ddlUniversite_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlFakulte.Items.Clear();
            int universiteId = int.Parse(ddlUniversite.SelectedValue);
            var fakulteBul = db.fakulte.Where(x => x.uniId == universiteId).ToList();
            ddlFakulte.DataValueField = "fakId";
            ddlFakulte.DataTextField = "fakAd";
            ddlFakulte.DataSource = fakulteBul;
            ddlFakulte.DataBind();
        }

        protected void ddlFakulte_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlBolum.Items.Clear();
            int universiteId = int.Parse(ddlUniversite.SelectedValue);
            int fakulteId = int.Parse(ddlFakulte.SelectedValue);
            var bolumBul = db.bolum.Where(x => x.uniId == universiteId && x.fakId == fakulteId).ToList();
            ddlBolum.DataValueField = "bolId";
            ddlBolum.DataTextField = "bolAd";
            ddlBolum.DataSource = bolumBul;
            ddlBolum.DataBind();
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            long tc = long.Parse(txtTckn.Text);
            var mukerrer = db.onKayit.Where(x => x.tckn == tc).ToList();
            if (mukerrer.Count == 0)
            {



                if (kontrol() == 0)
                {
                    onKayit kaydet = new onKayit();
                    kaydet.tckn = long.Parse(txtTckn.Text);
                    kaydet.ad = txtAd.Text;
                    kaydet.soyad = txtSoyad.Text;
                    kaydet.anneAd = txtAnneAd.Text;
                    kaydet.anneSoyad = txtAnneSoyad.Text;
                    kaydet.babaAd = txtBabaAd.Text;
                    kaydet.babaSoyad = txtBabaSoyad.Text;
                    kaydet.uniId = int.Parse(ddlUniversite.SelectedValue);
                    kaydet.fakId = int.Parse(ddlFakulte.SelectedValue);
                    kaydet.bolId = int.Parse(ddlBolum.SelectedValue);
                    kaydet.gsm = long.Parse(txtGsm.Text);
                    kaydet.email = txtEPosta.Text;
                    if (fuAles.HasFile)
                    {
                        string uzanti = fuAles.PostedFile.ContentType;
                        if (uzanti == "application/pdf")
                        {
                            var dosyaAdi = Path.GetFileName(Guid.NewGuid() + "" + "" + fuAles.FileName);
                            fuAles.SaveAs(Server.MapPath("~/doc/ales/" + dosyaAdi));

                            dokuman dok = new dokuman();
                            dok.docTur = "Ales";
                            dok.docYol = "/doc/ales/" + dosyaAdi;
                            dok.tckn = long.Parse(txtTckn.Text);
                            db.dokuman.Add(dok);
                            db.SaveChanges();
                            kaydet.ales = true;
                        }
                    }
                    else { kaydet.ales = false; }
                    if (fuDiploma.HasFile)
                    {
                        string uzanti = fuDiploma.PostedFile.ContentType;
                        if (uzanti == "application/pdf")
                        {
                            var dosyaAdi = Path.GetFileName(Guid.NewGuid() + "" + "" + fuDiploma.FileName);
                            fuAles.SaveAs(Server.MapPath("~/doc/diploma/" + dosyaAdi));

                            dokuman dok = new dokuman();
                            dok.docTur = "Diploma";
                            dok.docYol = "/doc/diploma/" + dosyaAdi;
                            dok.tckn = long.Parse(txtTckn.Text);
                            db.dokuman.Add(dok);
                            db.SaveChanges();
                            kaydet.diploma = true;
                        }

                    }
                    else { kaydet.diploma = false; }
                    if (fuAskerlik.HasFile)
                    {
                        string uzanti = fuAskerlik.PostedFile.ContentType;
                        if (uzanti == "application/pdf")
                        {
                            var dosyaAdi = Path.GetFileName(Guid.NewGuid() + "" + "" + fuAskerlik.FileName);
                            fuAles.SaveAs(Server.MapPath("~/doc/askerlik/" + dosyaAdi));

                            dokuman dok = new dokuman();
                            dok.docTur = "Diploma";
                            dok.docYol = "/doc/askerlik/" + dosyaAdi;
                            dok.tckn = long.Parse(txtTckn.Text);
                            db.dokuman.Add(dok);
                            db.SaveChanges();
                            kaydet.askerlik = true;
                        }

                    }
                    else { kaydet.askerlik = false; }

                    db.onKayit.Add(kaydet);
                    db.SaveChanges();

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Kayıt İşlemi Başarılı')", true);


                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Lütfen girilen Bilgileri kontrol ediniz')", true);

                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Önceden Ön Kayıt Yaptırdığınız için tekrardan Ön Kayıt Yaptıramazsınız.')", true);
            }
        }
        int durum;
        int kontrol()
        {

            if (
                txtTckn.BorderColor == System.Drawing.Color.LightGreen &&
                txtAd.Text != string.Empty &&
                txtAd.Text != string.Empty &&
                txtSoyad.Text != string.Empty &&
                txtAnneAd.Text != string.Empty &&
                txtAnneSoyad.Text != string.Empty &&
                txtBabaAd.Text != string.Empty &&
                txtBabaSoyad.Text != string.Empty &&
                ddlUniversite.SelectedValue != "-1" &&
                ddlFakulte.SelectedValue != "-1" &&
                ddlBolum.SelectedValue != "-1" &&
                txtGsm.Text != string.Empty &&
                txtEPosta.Text != string.Empty
                )
            {
                durum = 0;
                if (fuAles.HasFile)
                {
                    if (fuAles.PostedFile.ContentType == "application/pdf")
                    {
                        durum = 0;
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Yüklenecek dosya PDF Formatında olmalıdır')", true);
                        durum++;

                    }

                }
                if (fuDiploma.HasFile)
                {
                    if (fuDiploma.PostedFile.ContentType == "application/pdf")
                    {
                        durum = 0;
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Yüklenecek dosya PDF Formatında olmalıdır')", true);
                        durum++;
                    }

                }
                if (fuAskerlik.HasFile)
                {
                    if (fuAskerlik.PostedFile.ContentType == "application/pdf")
                    {
                        durum = 0;
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Yüklenecek dosya PDF Formatında olmalıdır')", true);
                        durum++;
                    }

                }

            }

            else
            {
                durum++;
            }
            return durum;




        }
    }
}