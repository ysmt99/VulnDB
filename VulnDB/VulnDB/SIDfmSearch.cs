using SIDfmContext.db;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace VulnDB
{
    class SIDfmSearch
    {
        internal static SIDfmViewList search()
        {
            using (SIDfmSQLiteEntities en = new SIDfmSQLiteEntities())
            {
                var connectionString = en.Database.Connection.ConnectionString;
                var matchCollection = Regex.Matches(connectionString, "source=(?<value>.*)", RegexOptions.IgnoreCase);
                if (matchCollection.Count > 0)
                {
                    foreach (Match match in matchCollection)
                    {
                        var fileName = match.Groups["value"].Value;
                        if (!File.Exists(fileName))
                            throw new ArgumentException("DBファイルが存在しません：" + fileName);
                        break;
                    }
                }
//                    List<SIDfm> beans =
//                     (from x in en.SIDfm
//                      orderby x.情報登録日 descending, x.SIDfmId, x.CVE番号
//                      select x);

                var beans = en.SIDfm.OrderBy(x => x.CVE番号).OrderBy(x => x.SIDfmId).OrderByDescending(x => x.情報登録日);
                SIDfmViewList views = new SIDfmViewList();
                foreach (var o in beans)
                {
                    views.Add(new SIDfmView(o));
                }

                return views;
            }
           // return  new List<SIDfmView>();
        }

        #region 脆弱性一覧のDataGridView登録データ
        /// <summary>
        /// 脆弱性一覧のDataGridView登録データ
        /// DataGridViewでのデータ並び替え対応のためにIBindingList継承・実装
        /// </summary>
        internal class SIDfmViewList : List<SIDfmView>, IBindingList
        {
            bool isSorted = false;

            #region IBindingList
            void IBindingList.AddIndex(PropertyDescriptor property)
            {
                throw new NotImplementedException();
            }

            object IBindingList.AddNew()
            {
                throw new NotImplementedException();
            }

            bool IBindingList.AllowEdit
            {
                get { return false; }
            }

            bool IBindingList.AllowNew
            {
                get { return false; }
            }

            bool IBindingList.AllowRemove
            {
                get { return false; }
            }

            void IBindingList.ApplySort(PropertyDescriptor property, ListSortDirection direction)
            {
                var memberType = typeof(SIDfmView);
                var memberDescriptor = property as System.ComponentModel.MemberDescriptor;
                this.Sort(new Comparison<SIDfmView>
                    ((v1, v2)
                        =>
                    {
                        var prop = memberType.GetProperty(memberDescriptor.Name);

                        var v1value = prop.GetValue(v1);
                        var v2value = prop.GetValue(v2);

                        int result = 0;
                        
                        if (prop.PropertyType == typeof(string))
                            result = string.Compare((string)v1value, (string)v2value);
                        else if (prop.PropertyType == typeof(int))
                            result = (int)v1value　- (int)v2value;

                        return (direction == ListSortDirection.Ascending) ? result : result * -1;
                    }
                    ));
                isSorted = true;
            }

            int IBindingList.Find(PropertyDescriptor property, object key)
            {
                throw new NotImplementedException();
            }

            bool IBindingList.IsSorted
            {
                get { return isSorted; }
            }

            event ListChangedEventHandler IBindingList.ListChanged
            {
                add { throw new NotImplementedException(); }
                remove { throw new NotImplementedException(); }
            }

            void IBindingList.RemoveIndex(PropertyDescriptor property)
            {
                throw new NotImplementedException();
            }

            void IBindingList.RemoveSort()
            {
                throw new NotImplementedException();
            }

            ListSortDirection IBindingList.SortDirection
            {
                get { throw new NotImplementedException(); }
            }

            PropertyDescriptor IBindingList.SortProperty
            {
                get { throw new NotImplementedException(); }
            }

            bool IBindingList.SupportsChangeNotification
            {
                get { return false; }
            }

            bool IBindingList.SupportsSearching
            {
                get { throw new NotImplementedException(); }
            }

            bool IBindingList.SupportsSorting
            {
                get { return true; }
            }

            int System.Collections.IList.Add(object value)
            {
                throw new NotImplementedException();
            }

            void System.Collections.IList.Clear()
            {
                throw new NotImplementedException();
            }

            bool System.Collections.IList.Contains(object value)
            {
                throw new NotImplementedException();
            }

            int System.Collections.IList.IndexOf(object value)
            {
                throw new NotImplementedException();
            }

            void System.Collections.IList.Insert(int index, object value)
            {
                throw new NotImplementedException();
            }

            bool System.Collections.IList.IsFixedSize
            {
                get { throw new NotImplementedException(); }
            }

            bool System.Collections.IList.IsReadOnly
            {
                get { throw new NotImplementedException(); }
            }

            void System.Collections.IList.Remove(object value)
            {
                throw new NotImplementedException();
            }

            void System.Collections.IList.RemoveAt(int index)
            {
                throw new NotImplementedException();
            }

            object System.Collections.IList.this[int index]
            {
                get
                {
                    return this[index];
                }
                set
                {
                    this[index] = value as SIDfmView;
                }
            }

            void System.Collections.ICollection.CopyTo(Array array, int index)
            {
                throw new NotImplementedException();
            }

            int System.Collections.ICollection.Count
            {
                get { return this.Count; }
            }

            bool System.Collections.ICollection.IsSynchronized
            {
                get { throw new NotImplementedException(); }
            }

            object System.Collections.ICollection.SyncRoot
            {
                get { throw new NotImplementedException(); }
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }
        #endregion IBindingList
    }
    #endregion 脆弱性一覧のDataGridView登録データ
}
