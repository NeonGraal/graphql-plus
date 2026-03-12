namespace GqlPlus.Result;

internal interface IResultPartial<T> : IResultValue<T>, IResultMessage;
