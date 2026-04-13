//HintName: test_union-descr_Model.gen.cs
// Generated from {CurrentDirectory}union-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_descr;

public class testUnionDescr
  : GqlpModelBase
  , ItestUnionDescr
{
  private object? _value;
  public bool HasA<T>() => _value is T;
  public T AsA<T>() => (T)_value!;
}
