// Copyright (c) Microsoft Corporation. All Rights Reserved.
// Licensed under the MIT License.

using System;
using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Datasync
{
    /// <summary>
    /// A list of options for configuring the <see cref="TableController{TEntity}"/>.
    /// </summary>
    public class TableControllerOptions
    {
        private int _pageSize = 100;
        private int _maxTop = 512000;
        private int _maxAnyAllExpressionDepth = 1;
        private int _maxExpansionDepth = 2;
        private int _maxNodeCount = 100;

        /// <summary>
        /// The page size of the results returned by a query operation.  This is also the maximum
        /// value that can be provided with the <c>$top</c> query option on list requests.
        /// </summary>
        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                if (value <= 0 || value > 128000)
                {
                    throw new ArgumentException("PageSize value range is 1 - 128,000", nameof(PageSize));
                }
                _pageSize = value;
            }
        }

        public int MaxTop
        {
            get { return _maxTop; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("MaxTop value range is 1+", nameof(MaxTop));
                }
                _maxTop = value;
            }
        }
        public int MaxAnyAllExpressionDepth
        {
            get { return _maxAnyAllExpressionDepth; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("MaxAnyAllExpressionDepth value range is 1+", nameof(MaxAnyAllExpressionDepth));
                }
                _maxAnyAllExpressionDepth = value;
            }
        }
        public int MaxExpansionDepth 
        { 
            get { return _maxExpansionDepth; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("MaxExpansionDepth value range is 1+", nameof(MaxExpansionDepth));
                }
                _maxExpansionDepth = value;
            }
        }
        public int MaxNodeCount
        {
            get { return _maxNodeCount; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("MaxNodeCount value range is 1+", nameof(MaxNodeCount));
                }
                _maxNodeCount = value;
            }
        }
        /// <summary>
        /// True if soft delete is enabled.  By default, soft delete is turned off
        /// (for backwards compatibility with Azure Mobile Apps v2.0)
        /// </summary>
        public bool EnableSoftDelete { get; set; } = false;

        /// <summary>
        /// The status code returned when the user is unauthorized.
        /// </summary>
        public int UnauthorizedStatusCode { get; set; } = StatusCodes.Status401Unauthorized;
    }
}
