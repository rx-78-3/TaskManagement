import React from 'react';

const Pagination = ({ currentPage, totalCount, pageSize, onPageChange }) => {
    const totalPages = Math.ceil(totalCount / pageSize);

    const handlePageClick = (page) => {
        if (page >= 0 && page < totalPages) {
            onPageChange(page);
        }
    };

    const pageNumbers = [];
    for (let i = 0; i < totalPages; i++) {
        pageNumbers.push(
            <li key={i + 1} className={`page-item ${currentPage === i ? 'active' : ''}`}>
                <button className="page-link" onClick={() => handlePageClick(i)}>
                    {i + 1}
                </button>
            </li>
        );
    }

    return (
        <nav aria-label="Page navigation">
            <ul className="pagination">
                <li className="page-item">
                    <button 
                        className="page-link" 
                        onClick={() => handlePageClick(currentPage - 1)} 
                        disabled={currentPage === 0}
                    >
                        Previous
                    </button>
                </li>
                {pageNumbers}
                <li className="page-item">
                    <button 
                        className="page-link" 
                        onClick={() => handlePageClick(currentPage + 1)} 
                        disabled={currentPage === totalPages - 1}
                    >
                        Next
                    </button>
                </li>
            </ul>
        </nav>
    );
};

export default Pagination;