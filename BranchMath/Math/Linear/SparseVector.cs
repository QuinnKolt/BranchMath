using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BranchMath.Math.Arithmetic;

namespace BranchMath.Math.Linear {
    public class SparseVector<R> : Vector<R>, Scalable<SparseVector<R>, R> where R : FieldLikeObject<R> {
        private readonly ConcurrentDictionary<int, R> sparse_entries;

        public SparseVector(Dictionary<int, R> sparse_entries) : base(null) {
            this.sparse_entries = new ConcurrentDictionary<int, R>(sparse_entries);
        }
        
        public SparseVector(ConcurrentDictionary<int, R> sparse_entries) : base(null) {
            this.sparse_entries = sparse_entries;
        }
        
        public override object evaluate() {
            return sparse_entries;
        }

        public R dot(SparseVector<R> v) {
            
            var r = default(R);
            var started = false;
            Parallel.ForEach(sparse_entries.Keys, i => {
                if (v.sparse_entries.ContainsKey(i)) {
                    if (started) {
                        Debug.Assert(r != null, nameof(r) + " != null");
                        r = r.plus(sparse_entries[i].times(v[i]));
                    }
                    else {
                        r = sparse_entries[i].times(v[i]);
                        started = true;
                    }
                }
            });
            
            return r;
        }
        
        public override R dot(Vector<R> v) {
            if (v is SparseVector<R> s)
                return dot(s);
            
            var r = default(R);
            var started = false;
            
            foreach (var i in sparse_entries.Keys) {
                if(started)
                    r = r.plus(sparse_entries[i].times(v[i]));
                else {
                    r = sparse_entries[i].times(v[i]);
                    started = true;
                }
            }

            return r;
        }

        public SparseVector<R> plus(SparseVector<R> a) {
            var ent = new ConcurrentDictionary<int, R>();
            
            Parallel.ForEach(sparse_entries.Keys, i => {
                if (a.sparse_entries.ContainsKey(i)) {
                    ent[i] = sparse_entries[i].plus(a.sparse_entries[i]);
                }
                else
                    ent[i] = sparse_entries[i];
            });
            
            Parallel.ForEach(a.sparse_entries.Keys.Where(j => 
                !sparse_entries.ContainsKey(j)), j => {
                ent[j] = a.sparse_entries[j];
            });

            return ent;
        }

        public new SparseVector<R> getZero() {
            return new SparseVector<R>(new ConcurrentDictionary<int, R>());
        }

        public SparseVector<R> minus(SparseVector<R> a) {
            var ent = new ConcurrentDictionary<int, R>();
            Parallel.ForEach(sparse_entries.Keys, i => {
                if (a.sparse_entries.ContainsKey(i)) {
                    ent[i] = sparse_entries[i].minus(a.sparse_entries[i]);
                }
                else
                    ent[i] = sparse_entries[i];
            });
            
            Parallel.ForEach(a.sparse_entries.Keys.Where(j =>
                !sparse_entries.ContainsKey(j)), body: j => ent[j] = a.sparse_entries[j]);

            return ent;
        }

        public new SparseVector<R> scale(R x) {
            if (sparse_entries.Count == 0)
                return this;
            
            var ent = new ConcurrentDictionary<int, R>();
            foreach (var i in sparse_entries.Keys) {
                ent[i] = x.times(sparse_entries[i]);
            }

            return ent;
        }

        public static implicit operator SparseVector<R>(Dictionary<int, R> entries) {
            return new SparseVector<R>(entries);
        } 
        
        public static implicit operator SparseVector<R>(ConcurrentDictionary<int, R> entries) {
            return new SparseVector<R>(entries);
        } 
        
        public static implicit operator ConcurrentDictionary<int, R>(SparseVector<R> vec) {
            return vec.sparse_entries;
        } 
    }
}