namespace GqlPlus;

public static class BuilderHelpers
{
  public static T Of<T>(this IMockBuilder _)
    where T : class
    => Substitute.For<T>();
  public static T Of<T, T1>(this IMockBuilder _)
    where T : class
    where T1 : class
    => Substitute.For<T, T1>();
  public static T Of<T, T1, T2>(this IMockBuilder _)
    where T : class, T1
    where T1 : class, T2
    where T2 : class
    => Substitute.For<T, T1, T2>();

  public static TResult[] ArrayOf<TResult, TInput>(this IMockBuilder builder, Func<IMockBuilder, TInput, TResult> build, params TInput[] input)
    where TResult : class
    => [.. input.Select(i => build(builder, i))];
}
