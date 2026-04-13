//HintName: test_union-parent-descr_Model.gen.cs
// Generated from {CurrentDirectory}union-parent-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_parent_descr;

public class testUnionPrntDescr
  : testPrntUnionPrntDescr
  , ItestUnionPrntDescr
{
}

public class testPrntUnionPrntDescr
  : GqlpModelBase
  , ItestPrntUnionPrntDescr
{
  private object? _value;
  public bool HasA<T>() => _value is T;
  public T AsA<T>() => (T)_value!;
}
