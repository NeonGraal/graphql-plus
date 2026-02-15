namespace GqlPlus.Result;

public interface IResultError<T> : IResultError, IResult<T>;

public interface IResultError : IResultMessage;
