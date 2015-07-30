using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDfmContext
{
    class Const
    {
        public enum 攻撃元key { ローカル = 1, 隣接 = 10, ネットワーク = 100 };
        public static Dictionary<攻撃元key, Object> 攻撃元 = new Dictionary<攻撃元key, Object>();
        public enum 攻撃成立条件key { 難しい = 1, やや難 = 10, 簡単 = 100 };
        public static Dictionary<攻撃成立条件key, Object> 攻撃成立条件 = new Dictionary<攻撃成立条件key, Object>();
        public enum 攻撃前の認証key { 複数 = 1, 単一 = 10, 不要 = 100 };
        public static Dictionary<攻撃前の認証key, Object> 攻撃前の認証 = new Dictionary<攻撃前の認証key, Object>();
        public enum 情報漏えいkey { 影響なし = 1, 部分的 = 10, 全面的 = 100 };
        public static Dictionary<情報漏えいkey, Object> 情報漏えい = new Dictionary<情報漏えいkey, Object>();
        public enum 情報改ざんkey { 影響なし = 1, 部分的 = 10, 全面的 = 100 };
        public static Dictionary<情報改ざんkey, Object> 情報改ざん = new Dictionary<情報改ざんkey, Object>();
        public enum 業務停止key { 影響なし = 1, 部分的 = 10, 全面的 = 100 };
        public static Dictionary<業務停止key, Object> 業務停止 = new Dictionary<業務停止key, Object>();

        static Const()
        {
            攻撃元[攻撃元key.ローカル] = new { text = "ローカル", calc = 0.4m };
            攻撃元[攻撃元key.隣接] = new { text = "隣接", calc = 0.6m };
            攻撃元[攻撃元key.ネットワーク] = new { text = "ネットワーク", calc = 1.0m };

            攻撃成立条件[攻撃成立条件key.難しい] = new { text = "難しい", calc = 0.4m };
            攻撃成立条件[攻撃成立条件key.やや難] = new { text = "やや難", calc = 0.6m };
            攻撃成立条件[攻撃成立条件key.簡単] = new { text = "簡単", calc = 0.7m };

            攻撃前の認証[攻撃前の認証key.複数] = new { text = "複数", calc = 0.5m };
            攻撃前の認証[攻撃前の認証key.単一] = new { text = "単一", calc = 0.6m };
            攻撃前の認証[攻撃前の認証key.不要] = new { text = "不要", calc = 0.7m };

            情報漏えい[情報漏えいkey.影響なし] = new { text = "影響なし", calc = 0.0m };
            情報漏えい[情報漏えいkey.部分的] = new { text = "部分的", calc = 0.3m };
            情報漏えい[情報漏えいkey.全面的] = new { text = "全面的", calc = 0.7m };

            情報改ざん[情報改ざんkey.影響なし] = new { text = "影響なし", calc = 0.0m };
            情報改ざん[情報改ざんkey.部分的] = new { text = "部分的", calc = 0.3m };
            情報改ざん[情報改ざんkey.全面的] = new { text = "全面的", calc = 0.7m };
            
            業務停止[業務停止key.影響なし] = new { text = "影響なし", calc = 0.0m };
            業務停止[業務停止key.部分的] = new { text = "部分的", calc = 0.3m };
            業務停止[業務停止key.全面的] = new { text = "全面的", calc = 0.7m };
        }
    }
}
