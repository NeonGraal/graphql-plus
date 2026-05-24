using GqlPlus.Ast.Schema;

namespace GqlPlus.Merging;

public class MergerListTests
  : SubstituteBase
{
  [Fact]
  public void ImplicitConvert_FromDelegate_ReturnsMergerList()
  {
    IMergeAll<IAstType> inner = A.Of<IMergeAll<IAstType>>();

    MergerList<IAstType>.D factory = () => [inner];
    MergerList<IAstType> result = factory;

    result.ShouldNotBeNull();
  }

  [Fact]
  public void ImplicitConvert_NullFactory_ThrowsArgumentNullException()
  {
    MergerList<IAstType>.D? factory = null;

    Action result = () => _ = (MergerList<IAstType>)factory!;

    result.ShouldThrow<ArgumentNullException>();
  }
}
