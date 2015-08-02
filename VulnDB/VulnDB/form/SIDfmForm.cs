﻿using SIDfmContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;
using CSV列 = VulnDB.Const.CSV列;
using 入力規則 = VulnDB.Const.入力規則;

namespace VulnDB
{
    class SIDfmForm
    {
        List<SIDfmFormValidator> validators;
        Dictionary<CSV列,string> values;

        public SIDfmForm()
        {
            validators = new List<SIDfmFormValidator>();
            
            validators.Add(new SIDfmFormValidator(CSV列.SIDfmId,new List<入力規則>() { 入力規則.必須, 入力規則.整数 }));
            validators.Add(new SIDfmFormValidator(CSV列.タイトル,new List<入力規則>() { 入力規則.必須 }));
            validators.Add(new SIDfmFormValidator(CSV列.CVE番号,new List<入力規則>() { 入力規則.必須 }));
            validators.Add(new SIDfmFormValidator(CSV列.CVSS基本値,new List<入力規則>() { 入力規則.数値_小数点あり }));
            validators.Add(new SIDfmFormValidator(CSV列.攻撃元_ローカル,new List<入力規則>() { 入力規則.スイッチ_0か1 }));
            validators.Add(new SIDfmFormValidator(CSV列.攻撃元_隣接,new List<入力規則>() { 入力規則.スイッチ_0か1 }));
            validators.Add(new SIDfmFormValidator(CSV列.攻撃元_ネットワーク,new List<入力規則>() { 入力規則.スイッチ_0か1 }));
            validators.Add(new SIDfmFormValidator(CSV列.攻撃成立条件_難しい,new List<入力規則>() { 入力規則.スイッチ_0か1 }));
            validators.Add(new SIDfmFormValidator(CSV列.攻撃成立条件_やや難,new List<入力規則>() { 入力規則.スイッチ_0か1 }));
            validators.Add(new SIDfmFormValidator(CSV列.攻撃成立条件_簡単,new List<入力規則>() { 入力規則.スイッチ_0か1 }));
            validators.Add(new SIDfmFormValidator(CSV列.攻撃前の認証_複数,new List<入力規則>() { 入力規則.スイッチ_0か1 }));
            validators.Add(new SIDfmFormValidator(CSV列.攻撃前の認証_単一,new List<入力規則>() { 入力規則.スイッチ_0か1 }));
            validators.Add(new SIDfmFormValidator(CSV列.攻撃前の認証_不要,new List<入力規則>() { 入力規則.スイッチ_0か1 }));
            validators.Add(new SIDfmFormValidator(CSV列.情報漏えい_影響無し,new List<入力規則>() { 入力規則.スイッチ_0か1 }));
            validators.Add(new SIDfmFormValidator(CSV列.情報漏えい_部分的,new List<入力規則>() { 入力規則.スイッチ_0か1 }));
            validators.Add(new SIDfmFormValidator(CSV列.情報漏えい_全面的,new List<入力規則>() { 入力規則.スイッチ_0か1 }));
            validators.Add(new SIDfmFormValidator(CSV列.情報改ざん_影響無し,new List<入力規則>() { 入力規則.スイッチ_0か1 }));
            validators.Add(new SIDfmFormValidator(CSV列.情報改ざん_部分的,new List<入力規則>() { 入力規則.スイッチ_0か1 }));
            validators.Add(new SIDfmFormValidator(CSV列.情報改ざん_全面的,new List<入力規則>() { 入力規則.スイッチ_0か1 }));
            validators.Add(new SIDfmFormValidator(CSV列.業務停止_影響無し,new List<入力規則>() { 入力規則.スイッチ_0か1 }));
            validators.Add(new SIDfmFormValidator(CSV列.業務停止_部分的,new List<入力規則>() { 入力規則.スイッチ_0か1 }));
            validators.Add(new SIDfmFormValidator(CSV列.業務停止_全面的,new List<入力規則>() { 入力規則.スイッチ_0か1 }));
            validators.Add(new SIDfmFormValidator(CSV列.攻撃コードの有無,new List<入力規則>() { 入力規則.スイッチ_0か1 }));
            validators.Add(new SIDfmFormValidator(CSV列.情報登録日,new List<入力規則>() { 入力規則.日付 }));
            validators.Add(new SIDfmFormValidator(CSV列.アイテム1, new List<入力規則>() { 入力規則.日付 }));
            validators.Add(new SIDfmFormValidator(CSV列.アイテム2, new List<入力規則>() { 入力規則.日付 }));
            validators.Add(new SIDfmFormValidator(CSV列.アイテム3, new List<入力規則>() { 入力規則.日付 }));
            validators.Add(new SIDfmFormValidator(CSV列.アイテム4, new List<入力規則>() { 入力規則.日付 }));
            validators.Add(new SIDfmFormValidator(CSV列.アイテム5, new List<入力規則>() { 入力規則.日付 }));
            validators.Add(new SIDfmFormValidator(CSV列.アイテム6, new List<入力規則>() { 入力規則.日付 }));
            validators.Add(new SIDfmFormValidator(CSV列.アイテム7, new List<入力規則>() { 入力規則.日付 }));
            validators.Add(new SIDfmFormValidator(CSV列.アイテム8, new List<入力規則>() { 入力規則.日付 }));
            validators.Add(new SIDfmFormValidator(CSV列.アイテム9, new List<入力規則>() { 入力規則.日付 }));
            validators.Add(new SIDfmFormValidator(CSV列.アイテム10, new List<入力規則>() { 入力規則.日付 }));
        }
        public SIDfmForm(string[] ss)
        {
            // CSVファイルの値をセット
            foreach (CSV列 c in Enum.GetValues(typeof(CSV列)))
            {
                // CSVの列数は必ずしも揃っていない（アイテム欄がフィルタによって10未満になる）
                if ((int)c >= ss.Length)
                {
                    break;
                }
                values[c] = ss[(int)c];
            }
        }
        public SIDfmFormValidator getValidator(CSV列 key)
        {
            foreach (SIDfmFormValidator p in validators)
            {
                if (p.column == key)
                {
                    return p;
                }
            }
            return null;
        }
        public ErrorOfLine validateFormCSV(int lineNo)
        {
            ErrorOfLine errorOfLine = new ErrorOfLine();
            ErrorOfColumn errorOfColumn;
            foreach (SIDfmFormValidator v in validators)
            {
                errorOfColumn = v.validateByColumn(values[v.column]);
                errorOfLine.addError(v.column, errorOfColumn);
            }
            return errorOfLine;
        }
    }
}
