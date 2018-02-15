namespace DynamicContainer
{
    /// <summary>
    /// Indicates the access state of a resource
    /// </summary>
    public enum ResourceState
    {
        /// <summary>
        /// The resource is available and can be fetched for edit
        /// </summary>
        Available = 0,
        /// <summary>
        /// The resource has been locked by another user
        /// </summary>
        LockedByOther = 1,
        /// <summary>
        /// The resource has already been locked by the current user
        /// </summary>
        LockedByMe = 2
    }
}
