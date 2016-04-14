Infer class
----------------------------------------------------------------------

Does not extend anything
	Func 
	Expr 
 
XComparer class
----------------------------------------------------------------------

Does not extend anything
	By 
	ByDescending 

First argument is typeof(IComparer<T>) 
	ChainWith 
	Max 
	Min 
	Reverse 
	ThenBy 
	ThenByDescending
 

XEnumerable class
----------------------------------------------------------------------

Does not extend anything
	Unit 
	Empty 
	Generate 

First argument is non generic
	IsNullOrEmpty(IEnumerable)

First argument is generic
    Append(IEnumerable<TSource>) 
    Batch(IEnumerable<TSource>) 
    CommonPrefix(IEnumerable<TSource>) 
    DenseRankBy(IEnumerable<TSource>) 
    DenseRankByDescending(IEnumerable<TSource>) 
    DistinctBy(IEnumerable<TSource>) 
    DistinctUntilChanged(IEnumerable<TSource>) 
    DistinctUntilChangedBy(IEnumerable<TSource>) 
    ElementAtOrDefault(IEnumerable<TSource>) 
    ExceptBy(IEnumerable<TSource>) 
    FirstOrDefault(IEnumerable<TSource>) 
    Flatten(IEnumerable<TNode>) 
    FullOuterJoin(IEnumerable<TLeft>) 
    IndexOf(IEnumerable<TSource>) 
    IndexOfSubstring(IEnumerable<TSource>) 
    IntersectBy(IEnumerable<TSource>) 
    IsNullOrEmpty(IEnumerable<TSource>) 
    LastIndexOf(IEnumerable<TSource>) 
    LastOrDefault(IEnumerable<TSource>) 
    LeftOuterJoin(IEnumerable<TLeft>) 
    Max(IEnumerable<TSource>) 
    MaxBy(IEnumerable<TSource>) 
    Min(IEnumerable<TSource>) 
    MinBy(IEnumerable<TSource>) 
    None(IEnumerable<TSource>) 
    Prepend(IEnumerable<TSource>) 
    RankBy(IEnumerable<TSource>) 
    RankByDescending(IEnumerable<TSource>) 
    RightOuterJoin(IEnumerable<TLeft>) 
    SequenceEqualBy(IEnumerable<TSource>) 
    SingleOrDefault(IEnumerable<TSource>) 
    ToHashSet(IEnumerable<TSource>) 
    ToHierarchy(IEnumerable<TSource>) 
    ToLinkedList(IEnumerable<TSource>) 
    ToQueue(IEnumerable<TSource>) 
    ToStack(IEnumerable<TSource>) 
    UnionBy(IEnumerable<TSource>) 
    WithIndex(IEnumerable<TSource>) 
    WithoutIndex(IEnumerable<IIndexedItem<TSource>>) 

XEqualityComparer class
----------------------------------------------------------------------

Does not extend anything
	By

XList class
----------------------------------------------------------------------

First argument is generic
	AsReadOnly(IList<T>) 
	Shuffle(IList<T>) 
	Swap(IList<T>)
